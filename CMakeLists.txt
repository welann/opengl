cmake_minimum_required(VERSION 3.20)
project(opengl)

set(CMAKE_CXX_STANDARD 14)

include_directories("D:/OpenGL/glad 4.1/include")
include_directories("D:/OpenGL/glfw-3.3.5/include/GLFW")

add_executable(opengl main.cpp glad.c)
# Create library link a executable
target_link_libraries(opengl "D:/OpenGL/glfw-3.3.5/lib-mingw-w64/libglfw3.a" "D:/OpenGL/glfw-3.3.5/lib-mingw-w64/libglfw3dll.a" )