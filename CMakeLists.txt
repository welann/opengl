cmake_minimum_required(VERSION 3.20)

set(CMAKE_TOOLCHAIN_FILE "D:/vcpkg/scripts/buildsystems/vcpkg.cmake")

set(CMAKE_CXX_STANDARD 14)
project(opengl)
#if(DEFINED ENV{VCPKG_DEFAULT_TRIPLET} AND NOT DEFINED VCPKG_TARGET_TRIPLET)
#    set(VCPKG_TARGET_TRIPLET "$ENV{VCPKG_DEFAULT_TRIPLET}" CACHE STRING "")
#endif()


find_package(assimp CONFIG REQUIRED)

#find_package(Eigen3 CONFIG REQUIRED)
include_directories("D:/Env/OpenGL/glad 4.1/include")
include_directories("D:/Env/OpenGL/glfw-3.3.5/include")
include_directories("D:/Env/glm-0.9.9.8/glm")

add_executable(opengl main.cpp glad.c include/shader.h include/stb_image.h stbimage.cpp include/shader_s.h include/camera.h)
# Create library link a executable
target_link_libraries(opengl "D:/Env/OpenGL/glfw-3.3.5/lib-mingw-w64/libglfw3.a" "D:/Env/OpenGL/glfw-3.3.5/lib-mingw-w64/libglfw3dll.a" assimp::assimp)
#target_link_libraries(opengl PRIVATE  )