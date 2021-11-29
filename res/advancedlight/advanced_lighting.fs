#version 330 core
out vec4 FragColor;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
    vec2 TexCoords;
} fs_in;

uniform sampler2D floorTexture;
uniform vec3 lightPos[4];
uniform vec3 lightColors[4];
uniform vec3 viewPos;

uniform bool blinn;

// vec3 BlinnPhong(vec3 normal, vec3 fragPos, vec3 lightPos, vec3 lightColor)
vec3 BlinnPhong(vec3 normal, vec3 FragPos, vec3 lightPos, vec3 color)
{
    // diffuse
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * color;

//     vec3 diffuse = diff * lightColor;
// specular
    vec3 viewDir = normalize(viewPos - FragPos);

    vec3 halfwayDir = normalize(lightDir + viewDir);

    float spec = pow(max(dot(normal, halfwayDir), 0.0), 32.0);
    vec3 specular = vec3(0.5) * spec; // assuming bright white light color

    return diffuse + specular;
}

vec3 Phong(vec3 normal, vec3 FragPos, vec3 lightPos, vec3 color)
{
    // diffuse
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * color;

//     vec3 diffuse = diff * lightColor;
// specular
    vec3 viewDir = normalize(viewPos - FragPos);

    vec3 halfwayDir = normalize(lightDir + viewDir);
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 8.0);
//     float spec = pow(max(dot(normal, halfwayDir), 0.0), 32.0);
    vec3 specular = vec3(0.5) * spec; // assuming bright white light color

    return diffuse + specular;
}

void main()
{
    vec3 color = texture(floorTexture, fs_in.TexCoords).rgb;
    // ambient
    vec3 ambient = 0.05 * color;
    // diffuse
    vec3 normal = normalize(fs_in.Normal);
    // specular
    vec3 lighting = vec3(0.0);
    if(blinn){
        for(int i = 0; i < 4; ++i){
            lighting += BlinnPhong(normal, fs_in.FragPos, lightPos[i], color);
        }
    }
    else{
       for(int i = 0; i < 4; ++i){
           lighting += Phong(normal,fs_in.FragPos,lightPos[i],color);
       }
    }
//     vec3 specular = vec3(0.5) * spec; // assuming bright white light color
    FragColor = vec4(ambient + lighting, 1.0);
}