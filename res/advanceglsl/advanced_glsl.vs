//注意，从OpenGL 4.2版本起，你也可以添加一个布局标识符，显式地将Uniform块的绑定点储存在着色器中，
//这样就不用再调用glGetUniformBlockIndex和glUniformBlockBinding了。
//下面的代码显式地设置了Lights Uniform块的绑定点。
//所以要设置420
#version 420 core
layout (location = 0) in vec3 aPos;

layout (std140,binding = 0) uniform Matrices
{
    mat4 projection;
    mat4 view;
};
uniform mat4 model;

void main()
{
    gl_Position = projection * view * model * vec4(aPos, 1.0);
}