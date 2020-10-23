# Un C# binding a Uber H3 C biblioteca
## Problema
- DllNotFoundException: Unable to load shared library ... (En linux utilizando netcore 2.2 y 3.1)
## Compilar Uber H3
- Se debe crear una carpeta para compilar el proyecto H3, ejemplo: `/build`, y dentro de la carpeta `/build` ejecutar los comandos para compilar.
- Para compilar H3 en windows, genera un `.dll` en la carpeta  `/bin`
```
cmake -A x64 -DBUILD_SHARED_LIBS=ON -DCMAKE_POSITION_INDEPENDENT_CODE=ON -DCMAKE_BUILD_TYPE=Release ../h3
cmake --build . --target h3 --config Release
```
- Para compilar H3 en linux, genera un `.so.1` en la carpeta `/lib`
```
cmake -DBUILD_SHARED_LIBS=ON -DCMAKE_POSITION_INDEPENDENT_CODE=ON -DCMAKE_BUILD_TYPE=Release ../h3
cmake --build . --target h3 --config Release
```
## Referencias
[1]: https://ericsink.com/entries/native_library.html	"Dynamic loading of native code with .NET"
[2]: https://github.com/entrepreneur-interet-general/H3.Standard/blob/master/H3Standard/H3.cs	"H3Standard: A c# binding to Uber H3 C library"
[3]: https://developers.redhat.com/blog/2019/09/06/interacting-with-native-libraries-in-net-core-3-0/	"Interacting with native libraries in .NET Core 3.0"
[4]: https://github.com/sqrMin1/MonoGame.Forms/blob/master/Libs/MonoGame/_src/Windows/SDL/SDL2.cs	"Mercury Particle Sandbox"



