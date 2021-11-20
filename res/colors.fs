#version 330 core
out vec4 FragColor;

struct Material {
    sampler2D diffuse;
    sampler2D specular;
    sampler2D radi;
    float shininess;
};

struct Light {
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform vec3 viewPos;
uniform Material material;
uniform Light light;

//让绿色字符串动起来
uniform float matrixlight;
uniform float matrixmove;
// uniform float offset;



void main()
{
    // ambient
    vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;

    // diffuse
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * texture(material.diffuse, TexCoords).rgb;

    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * spec * texture(material.specular, TexCoords).rgb;
//     float x = TexCoords.x;
//     float y = TexCoords.y;
//
//     if (x < 0.2 || x > 0.8 || y < 0.2 || y > 0.8) {
//         emission = (sin(offset) / 2.0 + 0.5) * texture(material.radi, TexCoords + vec2(0.0, offset)).rgb;
//     } else {
//         emission = vec3(0.0);
//     }
    vec3 emission= matrixlight * texture(material.radi,vec2(TexCoords.x*0.7+0.1,TexCoords.y*0.7+0.1)+matrixmove).rgb;
    vec3 result = ambient + diffuse + specular+emission;
    FragColor = vec4(result, 1.0);
}