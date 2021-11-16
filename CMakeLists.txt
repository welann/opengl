cmake_minimum_required(VERSION 3.20)
project(opengl)

set(CMAKE_CXX_STANDARD 14)

include_directories("D:/Env/OpenGL/glad 4.1/include")
include_directories("D:/Env/OpenGL/glfw-3.3.5/include")
include_directories("D:/Env/glm-0.9.9.8/glm")
add_executable(opengl main.cpp glad.c Header/shader.h Header/stb_image.h stbimage.cpp Header/shader_s.h)
# Create library link a executable
target_link_libraries(opengl "D:/Env/OpenGL/glfw-3.3.5/lib-mingw-w64/libglfw3.a" "D:/Env/OpenGL/glfw-3.3.5/lib-mingw-w64/libglfw3dll.a" )