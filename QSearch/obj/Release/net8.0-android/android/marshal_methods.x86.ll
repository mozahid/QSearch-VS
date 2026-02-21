; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [124 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [248 x i32] [
	i32 42639949, ; 0: System.Threading.Thread => 0x28aa24d => 114
	i32 53857724, ; 1: ca/Microsoft.Maui.Controls.resources => 0x335cdbc => 1
	i32 72070932, ; 2: Microsoft.Maui.Graphics.dll => 0x44bb714 => 50
	i32 113429830, ; 3: zh-HK/Microsoft.Maui.Controls.resources => 0x6c2cd46 => 31
	i32 117431740, ; 4: System.Runtime.InteropServices => 0x6ffddbc => 109
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 60
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 78
	i32 195452805, ; 7: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 8: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 9: System.ComponentModel => 0xc38ff48 => 91
	i32 280992041, ; 10: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 318968648, ; 11: Xamarin.AndroidX.Activity.dll => 0x13031348 => 56
	i32 336156722, ; 12: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 13: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 67
	i32 347068432, ; 14: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 54
	i32 356389973, ; 15: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 357576608, ; 16: cs/Microsoft.Maui.Controls.resources => 0x15502fa0 => 2
	i32 379916513, ; 17: System.Threading.Thread.dll => 0x16a510e1 => 114
	i32 385762202, ; 18: System.Memory.dll => 0x16fe439a => 99
	i32 395744057, ; 19: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 435591531, ; 20: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 21: System.Collections => 0x1a61054f => 88
	i32 450948140, ; 22: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 66
	i32 456227837, ; 23: System.Web.HttpUtility.dll => 0x1b317bfd => 116
	i32 469710990, ; 24: System.dll => 0x1bff388e => 118
	i32 498788369, ; 25: System.ObjectModel => 0x1dbae811 => 105
	i32 500358224, ; 26: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 27: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 28: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 44
	i32 527168573, ; 29: hi/Microsoft.Maui.Controls.resources => 0x1f6bf43d => 10
	i32 539058512, ; 30: Microsoft.Extensions.Logging => 0x20216150 => 41
	i32 592146354, ; 31: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 597488923, ; 32: CommunityToolkit.Maui => 0x239cf51b => 35
	i32 627609679, ; 33: Xamarin.AndroidX.CustomView => 0x2568904f => 64
	i32 672442732, ; 34: System.Collections.Concurrent => 0x2814a96c => 85
	i32 688181140, ; 35: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 706645707, ; 36: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 37: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 38: System.Runtime.Loader.dll => 0x2b15ed29 => 110
	i32 748832960, ; 39: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 52
	i32 759454413, ; 40: System.Net.Requests => 0x2d445acd => 103
	i32 775507847, ; 41: System.IO.Compression => 0x2e394f87 => 96
	i32 789151979, ; 42: Microsoft.Extensions.Options => 0x2f0980eb => 43
	i32 823281589, ; 43: System.Private.Uri.dll => 0x311247b5 => 106
	i32 830298997, ; 44: System.IO.Compression.Brotli => 0x317d5b75 => 95
	i32 870878177, ; 45: ar/Microsoft.Maui.Controls.resources => 0x33e88be1 => 0
	i32 904024072, ; 46: System.ComponentModel.Primitives.dll => 0x35e25008 => 89
	i32 926902833, ; 47: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 967690846, ; 48: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 67
	i32 992768348, ; 49: System.Collections.dll => 0x3b2c715c => 88
	i32 993161700, ; 50: zh-Hans/Microsoft.Maui.Controls.resources => 0x3b3271e4 => 32
	i32 994547685, ; 51: es/Microsoft.Maui.Controls.resources => 0x3b4797e5 => 6
	i32 1012816738, ; 52: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 77
	i32 1028951442, ; 53: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 40
	i32 1029334545, ; 54: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 55: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 57
	i32 1044663988, ; 56: System.Linq.Expressions.dll => 0x3e444eb4 => 97
	i32 1052210849, ; 57: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 69
	i32 1082857460, ; 58: System.ComponentModel.TypeConverter => 0x408b17f4 => 90
	i32 1084122840, ; 59: Xamarin.Kotlin.StdLib => 0x409e66d8 => 82
	i32 1098259244, ; 60: System => 0x41761b2c => 118
	i32 1178241025, ; 61: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 74
	i32 1178797549, ; 62: fi/Microsoft.Maui.Controls.resources => 0x464305ed => 7
	i32 1203215381, ; 63: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1234928153, ; 64: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1292207520, ; 65: SQLitePCLRaw.core.dll => 0x4d0585a0 => 53
	i32 1293217323, ; 66: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 65
	i32 1324164729, ; 67: System.Linq => 0x4eed2679 => 98
	i32 1376866003, ; 68: Xamarin.AndroidX.SavedState => 0x52114ed3 => 77
	i32 1406073936, ; 69: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 61
	i32 1461234159, ; 70: System.Collections.Immutable.dll => 0x5718a9ef => 86
	i32 1462112819, ; 71: System.IO.Compression.dll => 0x57261233 => 96
	i32 1469204771, ; 72: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 58
	i32 1470490898, ; 73: Microsoft.Extensions.Primitives => 0x57a5e912 => 44
	i32 1479771757, ; 74: System.Collections.Immutable => 0x5833866d => 86
	i32 1480492111, ; 75: System.IO.Compression.Brotli.dll => 0x583e844f => 95
	i32 1493001747, ; 76: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1514721132, ; 77: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1543031311, ; 78: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 113
	i32 1551623176, ; 79: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1554762148, ; 80: fr/Microsoft.Maui.Controls.resources => 0x5cabc9a4 => 8
	i32 1580413037, ; 81: sv/Microsoft.Maui.Controls.resources => 0x5e33306d => 26
	i32 1591080825, ; 82: zh-Hant/Microsoft.Maui.Controls.resources => 0x5ed5f779 => 33
	i32 1622152042, ; 83: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 71
	i32 1624863272, ; 84: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 80
	i32 1634654947, ; 85: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 36
	i32 1636350590, ; 86: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 63
	i32 1639515021, ; 87: System.Net.Http.dll => 0x61b9038d => 100
	i32 1639986890, ; 88: System.Text.RegularExpressions => 0x61c036ca => 113
	i32 1657153582, ; 89: System.Runtime => 0x62c6282e => 111
	i32 1658251792, ; 90: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 81
	i32 1677501392, ; 91: System.Net.Primitives.dll => 0x63fca3d0 => 102
	i32 1679769178, ; 92: System.Security.Cryptography => 0x641f3e5a => 112
	i32 1711441057, ; 93: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 54
	i32 1729485958, ; 94: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 59
	i32 1736233607, ; 95: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1763938596, ; 96: System.Diagnostics.TraceSource.dll => 0x69239124 => 94
	i32 1766324549, ; 97: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 78
	i32 1770582343, ; 98: Microsoft.Extensions.Logging.dll => 0x6988f147 => 41
	i32 1780572499, ; 99: Mono.Android.Runtime.dll => 0x6a216153 => 122
	i32 1788241197, ; 100: Xamarin.AndroidX.Fragment => 0x6a96652d => 66
	i32 1808609942, ; 101: Xamarin.AndroidX.Loader => 0x6bcd3296 => 71
	i32 1809966115, ; 102: nb/Microsoft.Maui.Controls.resources => 0x6be1e423 => 18
	i32 1813058853, ; 103: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 82
	i32 1813201214, ; 104: Xamarin.Google.Android.Material => 0x6c13413e => 81
	i32 1818569960, ; 105: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 75
	i32 1821794637, ; 106: hu/Microsoft.Maui.Controls.resources => 0x6c96614d => 12
	i32 1828688058, ; 107: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 42
	i32 1842015223, ; 108: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1858542181, ; 109: System.Linq.Expressions => 0x6ec71a65 => 97
	i32 1910275211, ; 110: System.Collections.NonGeneric.dll => 0x71dc7c8b => 87
	i32 1960264639, ; 111: ja/Microsoft.Maui.Controls.resources => 0x74d743bf => 15
	i32 1968388702, ; 112: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 37
	i32 2014344398, ; 113: hr/Microsoft.Maui.Controls.resources => 0x781074ce => 11
	i32 2019465201, ; 114: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 69
	i32 2025202353, ; 115: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2043674646, ; 116: it/Microsoft.Maui.Controls.resources => 0x79d00016 => 14
	i32 2045470958, ; 117: System.Private.Xml => 0x79eb68ee => 107
	i32 2055257422, ; 118: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 68
	i32 2070888862, ; 119: System.Diagnostics.TraceSource => 0x7b6f419e => 94
	i32 2079903147, ; 120: System.Runtime.dll => 0x7bf8cdab => 111
	i32 2090596640, ; 121: System.Numerics.Vectors => 0x7c9bf920 => 104
	i32 2103459038, ; 122: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 55
	i32 2127167465, ; 123: System.Console => 0x7ec9ffe9 => 92
	i32 2150663486, ; 124: ko/Microsoft.Maui.Controls.resources => 0x8030853e => 16
	i32 2159891885, ; 125: Microsoft.Maui => 0x80bd55ad => 48
	i32 2165051842, ; 126: ro/Microsoft.Maui.Controls.resources => 0x810c11c2 => 23
	i32 2181898931, ; 127: Microsoft.Extensions.Options.dll => 0x820d22b3 => 43
	i32 2192057212, ; 128: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 42
	i32 2193016926, ; 129: System.ObjectModel.dll => 0x82b6c85e => 105
	i32 2201107256, ; 130: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 83
	i32 2201231467, ; 131: System.Net.Http => 0x8334206b => 100
	i32 2266799131, ; 132: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 38
	i32 2270573516, ; 133: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 134: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 76
	i32 2289298199, ; 135: th/Microsoft.Maui.Controls.resources => 0x8873eb17 => 27
	i32 2298471582, ; 136: System.Net.Mail => 0x88ffe49e => 101
	i32 2305521784, ; 137: System.Private.CoreLib.dll => 0x896b7878 => 120
	i32 2340441535, ; 138: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 108
	i32 2353062107, ; 139: System.Net.Primitives => 0x8c40e0db => 102
	i32 2368005991, ; 140: System.Xml.ReaderWriter.dll => 0x8d24e767 => 117
	i32 2369760409, ; 141: tr/Microsoft.Maui.Controls.resources => 0x8d3fac99 => 28
	i32 2371007202, ; 142: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 37
	i32 2401565422, ; 143: System.Web.HttpUtility => 0x8f24faee => 116
	i32 2421992093, ; 144: nl/Microsoft.Maui.Controls.resources => 0x905caa9d => 19
	i32 2435356389, ; 145: System.Console.dll => 0x912896e5 => 92
	i32 2465273461, ; 146: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 52
	i32 2471841756, ; 147: netstandard.dll => 0x93554fdc => 119
	i32 2475788418, ; 148: Java.Interop.dll => 0x93918882 => 121
	i32 2480646305, ; 149: Microsoft.Maui.Controls => 0x93dba8a1 => 46
	i32 2520433370, ; 150: sk/Microsoft.Maui.Controls.resources => 0x963ac2da => 25
	i32 2605712449, ; 151: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 83
	i32 2617129537, ; 152: System.Private.Xml.dll => 0x9bfe3a41 => 107
	i32 2620871830, ; 153: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 63
	i32 2663698177, ; 154: System.Runtime.Loader => 0x9ec4cf01 => 110
	i32 2732626843, ; 155: Xamarin.AndroidX.Activity => 0xa2e0939b => 56
	i32 2737747696, ; 156: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 58
	i32 2758225723, ; 157: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 47
	i32 2764765095, ; 158: Microsoft.Maui.dll => 0xa4caf7a7 => 48
	i32 2778768386, ; 159: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 79
	i32 2801831435, ; 160: Microsoft.Maui.Graphics => 0xa7008e0b => 50
	i32 2802068195, ; 161: uk/Microsoft.Maui.Controls.resources => 0xa7042ae3 => 29
	i32 2806116107, ; 162: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 163: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 61
	i32 2831556043, ; 164: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 165: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 79
	i32 2857259519, ; 166: el/Microsoft.Maui.Controls.resources => 0xaa4e51ff => 5
	i32 2861189240, ; 167: Microsoft.Maui.Essentials => 0xaa8a4878 => 49
	i32 2863743520, ; 168: QSearch.dll => 0xaab14220 => 84
	i32 2868488919, ; 169: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 36
	i32 2883495834, ; 170: ru/Microsoft.Maui.Controls.resources => 0xabdea79a => 24
	i32 2909740682, ; 171: System.Private.CoreLib => 0xad6f1e8a => 120
	i32 2916838712, ; 172: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 80
	i32 2919462931, ; 173: System.Numerics.Vectors.dll => 0xae037813 => 104
	i32 2959614098, ; 174: System.ComponentModel.dll => 0xb0682092 => 91
	i32 2978675010, ; 175: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 65
	i32 3038032645, ; 176: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 177: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 72
	i32 3059408633, ; 178: Mono.Android.Runtime => 0xb65adef9 => 122
	i32 3059793426, ; 179: System.ComponentModel.Primitives => 0xb660be12 => 89
	i32 3077302341, ; 180: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3106700962, ; 181: QSearch => 0xb92c7ea2 => 84
	i32 3178803400, ; 182: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 73
	i32 3220365878, ; 183: System.Threading => 0xbff2e236 => 115
	i32 3258312781, ; 184: Xamarin.AndroidX.CardView => 0xc235e84d => 59
	i32 3286872994, ; 185: SQLite-net.dll => 0xc3e9b3a2 => 51
	i32 3316684772, ; 186: System.Net.Requests.dll => 0xc5b097e4 => 103
	i32 3317135071, ; 187: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 64
	i32 3346324047, ; 188: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 74
	i32 3360279109, ; 189: SQLitePCLRaw.core => 0xc849ca45 => 53
	i32 3362522851, ; 190: Xamarin.AndroidX.Core => 0xc86c06e3 => 62
	i32 3366347497, ; 191: Java.Interop => 0xc8a662e9 => 121
	i32 3374999561, ; 192: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 76
	i32 3428513518, ; 193: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 39
	i32 3430777524, ; 194: netstandard => 0xcc7d82b4 => 119
	i32 3452344032, ; 195: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 45
	i32 3463511458, ; 196: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 197: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 90
	i32 3476120550, ; 198: Mono.Android => 0xcf3163e6 => 123
	i32 3479583265, ; 199: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3542658132, ; 200: vi/Microsoft.Maui.Controls.resources => 0xd328ac54 => 30
	i32 3596930546, ; 201: de/Microsoft.Maui.Controls.resources => 0xd664cdf2 => 4
	i32 3608519521, ; 202: System.Linq.dll => 0xd715a361 => 98
	i32 3623444314, ; 203: da/Microsoft.Maui.Controls.resources => 0xd7f95f5a => 3
	i32 3624195450, ; 204: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 108
	i32 3641597786, ; 205: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 68
	i32 3643854240, ; 206: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 73
	i32 3647796983, ; 207: pt-BR/Microsoft.Maui.Controls.resources => 0xd96cf6f7 => 21
	i32 3657292374, ; 208: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 38
	i32 3662115805, ; 209: he/Microsoft.Maui.Controls.resources => 0xda4773dd => 9
	i32 3672681054, ; 210: Mono.Android.dll => 0xdae8aa5e => 123
	i32 3686075795, ; 211: ms/Microsoft.Maui.Controls.resources => 0xdbb50d93 => 17
	i32 3697841164, ; 212: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3724971120, ; 213: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 72
	i32 3748608112, ; 214: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 93
	i32 3754567612, ; 215: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 55
	i32 3786282454, ; 216: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 60
	i32 3792276235, ; 217: System.Collections.NonGeneric => 0xe2098b0b => 87
	i32 3800979733, ; 218: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 45
	i32 3817368567, ; 219: CommunityToolkit.Maui.dll => 0xe3886bf7 => 35
	i32 3823082795, ; 220: System.Security.Cryptography.dll => 0xe3df9d2b => 112
	i32 3841636137, ; 221: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 40
	i32 3844307129, ; 222: System.Net.Mail.dll => 0xe52378b9 => 101
	i32 3849253459, ; 223: System.Runtime.InteropServices.dll => 0xe56ef253 => 109
	i32 3876362041, ; 224: SQLite-net => 0xe70c9739 => 51
	i32 3889960447, ; 225: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 226: System.Collections.Concurrent.dll => 0xe839deed => 85
	i32 3896760992, ; 227: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 62
	i32 3928044579, ; 228: System.Xml.ReaderWriter => 0xea213423 => 117
	i32 3931092270, ; 229: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 75
	i32 3955647286, ; 230: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 57
	i32 3980434154, ; 231: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 232: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4025784931, ; 233: System.Memory => 0xeff49a63 => 99
	i32 4046471985, ; 234: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 47
	i32 4070331268, ; 235: id/Microsoft.Maui.Controls.resources => 0xf29c5384 => 13
	i32 4073602200, ; 236: System.Threading.dll => 0xf2ce3c98 => 115
	i32 4094352644, ; 237: Microsoft.Maui.Essentials.dll => 0xf40add04 => 49
	i32 4100113165, ; 238: System.Private.Uri => 0xf462c30d => 106
	i32 4102112229, ; 239: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4119206479, ; 240: pl/Microsoft.Maui.Controls.resources => 0xf5861a4f => 20
	i32 4125707920, ; 241: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 242: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 39
	i32 4182413190, ; 243: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 70
	i32 4213026141, ; 244: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 93
	i32 4234116406, ; 245: pt/Microsoft.Maui.Controls.resources => 0xfc5f7d36 => 22
	i32 4271975918, ; 246: Microsoft.Maui.Controls.dll => 0xfea12dee => 46
	i32 4292120959 ; 247: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 70
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [248 x i32] [
	i32 114, ; 0
	i32 1, ; 1
	i32 50, ; 2
	i32 31, ; 3
	i32 109, ; 4
	i32 60, ; 5
	i32 78, ; 6
	i32 30, ; 7
	i32 31, ; 8
	i32 91, ; 9
	i32 2, ; 10
	i32 56, ; 11
	i32 15, ; 12
	i32 67, ; 13
	i32 54, ; 14
	i32 14, ; 15
	i32 2, ; 16
	i32 114, ; 17
	i32 99, ; 18
	i32 34, ; 19
	i32 26, ; 20
	i32 88, ; 21
	i32 66, ; 22
	i32 116, ; 23
	i32 118, ; 24
	i32 105, ; 25
	i32 13, ; 26
	i32 7, ; 27
	i32 44, ; 28
	i32 10, ; 29
	i32 41, ; 30
	i32 21, ; 31
	i32 35, ; 32
	i32 64, ; 33
	i32 85, ; 34
	i32 1, ; 35
	i32 16, ; 36
	i32 4, ; 37
	i32 110, ; 38
	i32 52, ; 39
	i32 103, ; 40
	i32 96, ; 41
	i32 43, ; 42
	i32 106, ; 43
	i32 95, ; 44
	i32 0, ; 45
	i32 89, ; 46
	i32 28, ; 47
	i32 67, ; 48
	i32 88, ; 49
	i32 32, ; 50
	i32 6, ; 51
	i32 77, ; 52
	i32 40, ; 53
	i32 3, ; 54
	i32 57, ; 55
	i32 97, ; 56
	i32 69, ; 57
	i32 90, ; 58
	i32 82, ; 59
	i32 118, ; 60
	i32 74, ; 61
	i32 7, ; 62
	i32 20, ; 63
	i32 18, ; 64
	i32 53, ; 65
	i32 65, ; 66
	i32 98, ; 67
	i32 77, ; 68
	i32 61, ; 69
	i32 86, ; 70
	i32 96, ; 71
	i32 58, ; 72
	i32 44, ; 73
	i32 86, ; 74
	i32 95, ; 75
	i32 10, ; 76
	i32 5, ; 77
	i32 113, ; 78
	i32 25, ; 79
	i32 8, ; 80
	i32 26, ; 81
	i32 33, ; 82
	i32 71, ; 83
	i32 80, ; 84
	i32 36, ; 85
	i32 63, ; 86
	i32 100, ; 87
	i32 113, ; 88
	i32 111, ; 89
	i32 81, ; 90
	i32 102, ; 91
	i32 112, ; 92
	i32 54, ; 93
	i32 59, ; 94
	i32 23, ; 95
	i32 94, ; 96
	i32 78, ; 97
	i32 41, ; 98
	i32 122, ; 99
	i32 66, ; 100
	i32 71, ; 101
	i32 18, ; 102
	i32 82, ; 103
	i32 81, ; 104
	i32 75, ; 105
	i32 12, ; 106
	i32 42, ; 107
	i32 29, ; 108
	i32 97, ; 109
	i32 87, ; 110
	i32 15, ; 111
	i32 37, ; 112
	i32 11, ; 113
	i32 69, ; 114
	i32 0, ; 115
	i32 14, ; 116
	i32 107, ; 117
	i32 68, ; 118
	i32 94, ; 119
	i32 111, ; 120
	i32 104, ; 121
	i32 55, ; 122
	i32 92, ; 123
	i32 16, ; 124
	i32 48, ; 125
	i32 23, ; 126
	i32 43, ; 127
	i32 42, ; 128
	i32 105, ; 129
	i32 83, ; 130
	i32 100, ; 131
	i32 38, ; 132
	i32 8, ; 133
	i32 76, ; 134
	i32 27, ; 135
	i32 101, ; 136
	i32 120, ; 137
	i32 108, ; 138
	i32 102, ; 139
	i32 117, ; 140
	i32 28, ; 141
	i32 37, ; 142
	i32 116, ; 143
	i32 19, ; 144
	i32 92, ; 145
	i32 52, ; 146
	i32 119, ; 147
	i32 121, ; 148
	i32 46, ; 149
	i32 25, ; 150
	i32 83, ; 151
	i32 107, ; 152
	i32 63, ; 153
	i32 110, ; 154
	i32 56, ; 155
	i32 58, ; 156
	i32 47, ; 157
	i32 48, ; 158
	i32 79, ; 159
	i32 50, ; 160
	i32 29, ; 161
	i32 6, ; 162
	i32 61, ; 163
	i32 19, ; 164
	i32 79, ; 165
	i32 5, ; 166
	i32 49, ; 167
	i32 84, ; 168
	i32 36, ; 169
	i32 24, ; 170
	i32 120, ; 171
	i32 80, ; 172
	i32 104, ; 173
	i32 91, ; 174
	i32 65, ; 175
	i32 34, ; 176
	i32 72, ; 177
	i32 122, ; 178
	i32 89, ; 179
	i32 12, ; 180
	i32 84, ; 181
	i32 73, ; 182
	i32 115, ; 183
	i32 59, ; 184
	i32 51, ; 185
	i32 103, ; 186
	i32 64, ; 187
	i32 74, ; 188
	i32 53, ; 189
	i32 62, ; 190
	i32 121, ; 191
	i32 76, ; 192
	i32 39, ; 193
	i32 119, ; 194
	i32 45, ; 195
	i32 11, ; 196
	i32 90, ; 197
	i32 123, ; 198
	i32 24, ; 199
	i32 30, ; 200
	i32 4, ; 201
	i32 98, ; 202
	i32 3, ; 203
	i32 108, ; 204
	i32 68, ; 205
	i32 73, ; 206
	i32 21, ; 207
	i32 38, ; 208
	i32 9, ; 209
	i32 123, ; 210
	i32 17, ; 211
	i32 33, ; 212
	i32 72, ; 213
	i32 93, ; 214
	i32 55, ; 215
	i32 60, ; 216
	i32 87, ; 217
	i32 45, ; 218
	i32 35, ; 219
	i32 112, ; 220
	i32 40, ; 221
	i32 101, ; 222
	i32 109, ; 223
	i32 51, ; 224
	i32 32, ; 225
	i32 85, ; 226
	i32 62, ; 227
	i32 117, ; 228
	i32 75, ; 229
	i32 57, ; 230
	i32 27, ; 231
	i32 9, ; 232
	i32 99, ; 233
	i32 47, ; 234
	i32 13, ; 235
	i32 115, ; 236
	i32 49, ; 237
	i32 106, ; 238
	i32 22, ; 239
	i32 20, ; 240
	i32 17, ; 241
	i32 39, ; 242
	i32 70, ; 243
	i32 93, ; 244
	i32 22, ; 245
	i32 46, ; 246
	i32 70 ; 247
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ cdb777a0c306e3e0668f847433f82144d7ca745f"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
