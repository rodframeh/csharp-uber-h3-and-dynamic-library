using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class H3
    {
        public static IntPtr NativeLibrary = GetNativeLibrary();

        private static IntPtr GetNativeLibrary()
        {
            var ret = IntPtr.Zero;

            // Load bundled library
            var assemblyLocation = Path.GetDirectoryName(typeof(H3).Assembly.Location);
            if (CurrentPlatform.OS == OS.Windows && Environment.Is64BitProcess)
                ret = FuncLoader.LoadLibrary(Path.Combine(assemblyLocation, "x64/h3.dll"));
            else if (CurrentPlatform.OS == OS.Windows && !Environment.Is64BitProcess)
                ret = FuncLoader.LoadLibrary(Path.Combine(assemblyLocation, "x86/h3.dll"));
            else if (CurrentPlatform.OS == OS.Linux && Environment.Is64BitProcess)
                ret = FuncLoader.LoadLibrary(Path.Combine(assemblyLocation, "x64/h3.so"));
            else if (CurrentPlatform.OS == OS.Linux && !Environment.Is64BitProcess)
                ret = FuncLoader.LoadLibrary(Path.Combine(assemblyLocation, "x86/h3.so"));

            // Load system library
            if (ret == IntPtr.Zero)
            {
                if (CurrentPlatform.OS == OS.Windows)
                    ret = FuncLoader.LoadLibrary("C:/Users/Jimena/Desktop/h3.dll");
                else if (CurrentPlatform.OS == OS.Linux)
                    ret = FuncLoader.LoadLibrary("../../libh3.so.1");
                else
                    ret = FuncLoader.LoadLibrary("libopenal.1.dylib");
            }

            return ret;
        }

        /*[CLSCompliant(false)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void d_alenable(int cap);
        internal static d_alenable Enable = FuncLoader.LoadFunction<d_alenable>(NativeLibrary, "alEnable");*/

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate ulong geoToH3(ref H3GeoCoord g, int res);
        internal static geoToH3 _geoToH3 = FuncLoader.LoadFunction<geoToH3>(NativeLibrary, "geoToH3");


        public static ulong GeoToH3(double latitude, double longitude, int resolution)
        {
            var coord = new H3GeoCoord { lat = DegToRad(latitude), lon = DegToRad(longitude) };
            return _geoToH3(ref coord, resolution);
        }

        public static double DegToRad(double deg)
        {
            return deg * Math.PI / 180;
        }

        public static double RadToDeg(double rad)
        {
            var val = rad * 180 / Math.PI;
            if (val > 180) val = val - 360;
            return val;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct H3GeoCoord
    {
        public double lat;  ///< latitude in radians
        public double lon;  ///< longitude in radians

        public H3GeoCoord(GeoCoord coord)
        {
            lat = H3.DegToRad(coord.latitude);
            lon = H3.DegToRad(coord.longitude);
        }
    }


    public struct GeoCoord
    {
        public double latitude;
        public double longitude;

        public GeoCoord(double lat, double lon)
        {
            latitude = lat;
            longitude = lon;
        }

        public GeoCoord(H3GeoCoord coord)
        {
            latitude = H3.RadToDeg(coord.lat);
            longitude = H3.RadToDeg(coord.lon);
        }
    }
}
