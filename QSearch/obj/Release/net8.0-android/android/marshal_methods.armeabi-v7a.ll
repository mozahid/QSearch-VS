; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [136 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [272 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 104
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 103
	i32 42639949, ; 2: System.Threading.Thread => 0x28aa24d => 126
	i32 52239042, ; 3: HtmlAgilityPack => 0x31d1ac2 => 35
	i32 53857724, ; 4: ca/Microsoft.Maui.Controls.resources => 0x335cdbc => 1
	i32 72070932, ; 5: Microsoft.Maui.Graphics.dll => 0x44bb714 => 49
	i32 113429830, ; 6: zh-HK/Microsoft.Maui.Controls.resources => 0x6c2cd46 => 31
	i32 117431740, ; 7: System.Runtime.InteropServices => 0x6ffddbc => 119
	i32 122350210, ; 8: System.Threading.Channels.dll => 0x74aea82 => 125
	i32 142721839, ; 9: System.Net.WebHeaderCollection => 0x881c32f => 110
	i32 165246403, ; 10: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 60
	i32 182336117, ; 11: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 78
	i32 195452805, ; 12: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 13: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 14: System.ComponentModel => 0xc38ff48 => 91
	i32 246610117, ; 15: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 117
	i32 280992041, ; 16: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 318968648, ; 17: Xamarin.AndroidX.Activity.dll => 0x13031348 => 56
	i32 336156722, ; 18: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 19: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 67
	i32 347068432, ; 20: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 53
	i32 356389973, ; 21: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 357576608, ; 22: cs/Microsoft.Maui.Controls.resources => 0x15502fa0 => 2
	i32 375677976, ; 23: System.Net.ServicePoint.dll => 0x16646418 => 108
	i32 379916513, ; 24: System.Threading.Thread.dll => 0x16a510e1 => 126
	i32 385762202, ; 25: System.Memory.dll => 0x16fe439a => 101
	i32 390191546, ; 26: Plugin.LatestVersionStore => 0x1741d9ba => 55
	i32 395744057, ; 27: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 435591531, ; 28: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 29: System.Collections => 0x1a61054f => 88
	i32 450948140, ; 30: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 66
	i32 465846621, ; 31: mscorlib => 0x1bc4415d => 130
	i32 469710990, ; 32: System.dll => 0x1bff388e => 129
	i32 498788369, ; 33: System.ObjectModel => 0x1dbae811 => 113
	i32 500358224, ; 34: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 35: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 36: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 44
	i32 527168573, ; 37: hi/Microsoft.Maui.Controls.resources => 0x1f6bf43d => 10
	i32 539058512, ; 38: Microsoft.Extensions.Logging => 0x20216150 => 41
	i32 592146354, ; 39: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 627609679, ; 40: Xamarin.AndroidX.CustomView => 0x2568904f => 64
	i32 672442732, ; 41: System.Collections.Concurrent => 0x2814a96c => 85
	i32 683518922, ; 42: System.Net.Security => 0x28bdabca => 107
	i32 688181140, ; 43: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 706645707, ; 44: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 45: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 46: System.Runtime.Loader.dll => 0x2b15ed29 => 120
	i32 748832960, ; 47: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 51
	i32 759454413, ; 48: System.Net.Requests => 0x2d445acd => 106
	i32 775507847, ; 49: System.IO.Compression => 0x2e394f87 => 98
	i32 789151979, ; 50: Microsoft.Extensions.Options => 0x2f0980eb => 43
	i32 823281589, ; 51: System.Private.Uri.dll => 0x311247b5 => 114
	i32 830298997, ; 52: System.IO.Compression.Brotli => 0x317d5b75 => 97
	i32 870878177, ; 53: ar/Microsoft.Maui.Controls.resources => 0x33e88be1 => 0
	i32 904024072, ; 54: System.ComponentModel.Primitives.dll => 0x35e25008 => 89
	i32 926902833, ; 55: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 967690846, ; 56: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 67
	i32 992768348, ; 57: System.Collections.dll => 0x3b2c715c => 88
	i32 993161700, ; 58: zh-Hans/Microsoft.Maui.Controls.resources => 0x3b3271e4 => 32
	i32 994547685, ; 59: es/Microsoft.Maui.Controls.resources => 0x3b4797e5 => 6
	i32 1012816738, ; 60: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 77
	i32 1028951442, ; 61: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 40
	i32 1029334545, ; 62: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 63: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 57
	i32 1044663988, ; 64: System.Linq.Expressions.dll => 0x3e444eb4 => 99
	i32 1052210849, ; 65: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 69
	i32 1082857460, ; 66: System.ComponentModel.TypeConverter => 0x408b17f4 => 90
	i32 1084122840, ; 67: Xamarin.Kotlin.StdLib => 0x409e66d8 => 82
	i32 1098259244, ; 68: System => 0x41761b2c => 129
	i32 1178241025, ; 69: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 74
	i32 1178797549, ; 70: fi/Microsoft.Maui.Controls.resources => 0x464305ed => 7
	i32 1203215381, ; 71: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1234928153, ; 72: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1292207520, ; 73: SQLitePCLRaw.core.dll => 0x4d0585a0 => 52
	i32 1293217323, ; 74: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 65
	i32 1324164729, ; 75: System.Linq => 0x4eed2679 => 100
	i32 1376866003, ; 76: Xamarin.AndroidX.SavedState => 0x52114ed3 => 77
	i32 1406073936, ; 77: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 61
	i32 1452070440, ; 78: System.Formats.Asn1.dll => 0x568cd628 => 96
	i32 1458022317, ; 79: System.Net.Security.dll => 0x56e7a7ad => 107
	i32 1462112819, ; 80: System.IO.Compression.dll => 0x57261233 => 98
	i32 1469204771, ; 81: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 58
	i32 1470490898, ; 82: Microsoft.Extensions.Primitives => 0x57a5e912 => 44
	i32 1480492111, ; 83: System.IO.Compression.Brotli.dll => 0x583e844f => 97
	i32 1493001747, ; 84: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1514721132, ; 85: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1543031311, ; 86: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 124
	i32 1551623176, ; 87: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1554762148, ; 88: fr/Microsoft.Maui.Controls.resources => 0x5cabc9a4 => 8
	i32 1580413037, ; 89: sv/Microsoft.Maui.Controls.resources => 0x5e33306d => 26
	i32 1591080825, ; 90: zh-Hant/Microsoft.Maui.Controls.resources => 0x5ed5f779 => 33
	i32 1622152042, ; 91: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 71
	i32 1624863272, ; 92: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 80
	i32 1636350590, ; 93: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 63
	i32 1639515021, ; 94: System.Net.Http.dll => 0x61b9038d => 102
	i32 1639986890, ; 95: System.Text.RegularExpressions => 0x61c036ca => 124
	i32 1657153582, ; 96: System.Runtime => 0x62c6282e => 122
	i32 1658251792, ; 97: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 81
	i32 1677501392, ; 98: System.Net.Primitives.dll => 0x63fca3d0 => 105
	i32 1679769178, ; 99: System.Security.Cryptography => 0x641f3e5a => 123
	i32 1711441057, ; 100: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 53
	i32 1729485958, ; 101: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 59
	i32 1736233607, ; 102: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1763938596, ; 103: System.Diagnostics.TraceSource.dll => 0x69239124 => 95
	i32 1766324549, ; 104: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 78
	i32 1770582343, ; 105: Microsoft.Extensions.Logging.dll => 0x6988f147 => 41
	i32 1776026572, ; 106: System.Core.dll => 0x69dc03cc => 93
	i32 1780572499, ; 107: Mono.Android.Runtime.dll => 0x6a216153 => 134
	i32 1788241197, ; 108: Xamarin.AndroidX.Fragment => 0x6a96652d => 66
	i32 1808609942, ; 109: Xamarin.AndroidX.Loader => 0x6bcd3296 => 71
	i32 1809966115, ; 110: nb/Microsoft.Maui.Controls.resources => 0x6be1e423 => 18
	i32 1813058853, ; 111: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 82
	i32 1813201214, ; 112: Xamarin.Google.Android.Material => 0x6c13413e => 81
	i32 1818569960, ; 113: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 75
	i32 1821794637, ; 114: hu/Microsoft.Maui.Controls.resources => 0x6c96614d => 12
	i32 1828688058, ; 115: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 42
	i32 1842015223, ; 116: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1858542181, ; 117: System.Linq.Expressions => 0x6ec71a65 => 99
	i32 1910275211, ; 118: System.Collections.NonGeneric.dll => 0x71dc7c8b => 86
	i32 1960264639, ; 119: ja/Microsoft.Maui.Controls.resources => 0x74d743bf => 15
	i32 1968388702, ; 120: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 37
	i32 1970841163, ; 121: Plugin.LatestVersionStore.dll => 0x7578a64b => 55
	i32 2014344398, ; 122: hr/Microsoft.Maui.Controls.resources => 0x781074ce => 11
	i32 2019465201, ; 123: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 69
	i32 2025202353, ; 124: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2043674646, ; 125: it/Microsoft.Maui.Controls.resources => 0x79d00016 => 14
	i32 2045470958, ; 126: System.Private.Xml => 0x79eb68ee => 115
	i32 2055257422, ; 127: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 68
	i32 2070888862, ; 128: System.Diagnostics.TraceSource => 0x7b6f419e => 95
	i32 2079903147, ; 129: System.Runtime.dll => 0x7bf8cdab => 122
	i32 2090596640, ; 130: System.Numerics.Vectors => 0x7c9bf920 => 112
	i32 2103459038, ; 131: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 54
	i32 2127167465, ; 132: System.Console => 0x7ec9ffe9 => 92
	i32 2142473426, ; 133: System.Collections.Specialized => 0x7fb38cd2 => 87
	i32 2150663486, ; 134: ko/Microsoft.Maui.Controls.resources => 0x8030853e => 16
	i32 2159891885, ; 135: Microsoft.Maui => 0x80bd55ad => 47
	i32 2165051842, ; 136: ro/Microsoft.Maui.Controls.resources => 0x810c11c2 => 23
	i32 2181898931, ; 137: Microsoft.Extensions.Options.dll => 0x820d22b3 => 43
	i32 2192057212, ; 138: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 42
	i32 2193016926, ; 139: System.ObjectModel.dll => 0x82b6c85e => 113
	i32 2201107256, ; 140: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 83
	i32 2201231467, ; 141: System.Net.Http => 0x8334206b => 102
	i32 2263672642, ; 142: Jurassic => 0x86ece742 => 36
	i32 2266799131, ; 143: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 38
	i32 2270573516, ; 144: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 145: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 76
	i32 2289298199, ; 146: th/Microsoft.Maui.Controls.resources => 0x8873eb17 => 27
	i32 2295906218, ; 147: System.Net.Sockets => 0x88d8bfaa => 109
	i32 2305521784, ; 148: System.Private.CoreLib.dll => 0x896b7878 => 132
	i32 2340441535, ; 149: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 118
	i32 2353062107, ; 150: System.Net.Primitives => 0x8c40e0db => 105
	i32 2368005991, ; 151: System.Xml.ReaderWriter.dll => 0x8d24e767 => 128
	i32 2369760409, ; 152: tr/Microsoft.Maui.Controls.resources => 0x8d3fac99 => 28
	i32 2371007202, ; 153: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 37
	i32 2421992093, ; 154: nl/Microsoft.Maui.Controls.resources => 0x905caa9d => 19
	i32 2435356389, ; 155: System.Console.dll => 0x912896e5 => 92
	i32 2458678730, ; 156: System.Net.Sockets.dll => 0x928c75ca => 109
	i32 2465273461, ; 157: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 51
	i32 2471841756, ; 158: netstandard.dll => 0x93554fdc => 131
	i32 2475788418, ; 159: Java.Interop.dll => 0x93918882 => 133
	i32 2480646305, ; 160: Microsoft.Maui.Controls => 0x93dba8a1 => 45
	i32 2484371297, ; 161: System.Net.ServicePoint => 0x94147f61 => 108
	i32 2520433370, ; 162: sk/Microsoft.Maui.Controls.resources => 0x963ac2da => 25
	i32 2538310050, ; 163: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 117
	i32 2605712449, ; 164: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 83
	i32 2617129537, ; 165: System.Private.Xml.dll => 0x9bfe3a41 => 115
	i32 2620871830, ; 166: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 63
	i32 2663698177, ; 167: System.Runtime.Loader => 0x9ec4cf01 => 120
	i32 2724373263, ; 168: System.Runtime.Numerics.dll => 0xa262a30f => 121
	i32 2732626843, ; 169: Xamarin.AndroidX.Activity => 0xa2e0939b => 56
	i32 2735172069, ; 170: System.Threading.Channels => 0xa30769e5 => 125
	i32 2737747696, ; 171: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 58
	i32 2758225723, ; 172: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 46
	i32 2764765095, ; 173: Microsoft.Maui.dll => 0xa4caf7a7 => 47
	i32 2778768386, ; 174: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 79
	i32 2801831435, ; 175: Microsoft.Maui.Graphics => 0xa7008e0b => 49
	i32 2802068195, ; 176: uk/Microsoft.Maui.Controls.resources => 0xa7042ae3 => 29
	i32 2806116107, ; 177: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 178: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 61
	i32 2831556043, ; 179: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 180: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 79
	i32 2857259519, ; 181: el/Microsoft.Maui.Controls.resources => 0xaa4e51ff => 5
	i32 2861189240, ; 182: Microsoft.Maui.Essentials => 0xaa8a4878 => 48
	i32 2863743520, ; 183: QSearch.dll => 0xaab14220 => 84
	i32 2883495834, ; 184: ru/Microsoft.Maui.Controls.resources => 0xabdea79a => 24
	i32 2905242038, ; 185: mscorlib.dll => 0xad2a79b6 => 130
	i32 2909740682, ; 186: System.Private.CoreLib => 0xad6f1e8a => 132
	i32 2916838712, ; 187: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 80
	i32 2919462931, ; 188: System.Numerics.Vectors.dll => 0xae037813 => 112
	i32 2959614098, ; 189: System.ComponentModel.dll => 0xb0682092 => 91
	i32 2978675010, ; 190: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 65
	i32 3038032645, ; 191: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 192: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 72
	i32 3059408633, ; 193: Mono.Android.Runtime => 0xb65adef9 => 134
	i32 3059793426, ; 194: System.ComponentModel.Primitives => 0xb660be12 => 89
	i32 3077302341, ; 195: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3103600923, ; 196: System.Formats.Asn1 => 0xb8fd311b => 96
	i32 3106700962, ; 197: QSearch => 0xb92c7ea2 => 84
	i32 3178803400, ; 198: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 73
	i32 3220365878, ; 199: System.Threading => 0xbff2e236 => 127
	i32 3258312781, ; 200: Xamarin.AndroidX.CardView => 0xc235e84d => 59
	i32 3286872994, ; 201: SQLite-net.dll => 0xc3e9b3a2 => 50
	i32 3316684772, ; 202: System.Net.Requests.dll => 0xc5b097e4 => 106
	i32 3317135071, ; 203: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 64
	i32 3346324047, ; 204: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 74
	i32 3360279109, ; 205: SQLitePCLRaw.core => 0xc849ca45 => 52
	i32 3362522851, ; 206: Xamarin.AndroidX.Core => 0xc86c06e3 => 62
	i32 3366347497, ; 207: Java.Interop => 0xc8a662e9 => 133
	i32 3374999561, ; 208: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 76
	i32 3428513518, ; 209: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 39
	i32 3430777524, ; 210: netstandard => 0xcc7d82b4 => 131
	i32 3463511458, ; 211: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 212: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 90
	i32 3476120550, ; 213: Mono.Android => 0xcf3163e6 => 135
	i32 3479583265, ; 214: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3542658132, ; 215: vi/Microsoft.Maui.Controls.resources => 0xd328ac54 => 30
	i32 3596930546, ; 216: de/Microsoft.Maui.Controls.resources => 0xd664cdf2 => 4
	i32 3608519521, ; 217: System.Linq.dll => 0xd715a361 => 100
	i32 3623444314, ; 218: da/Microsoft.Maui.Controls.resources => 0xd7f95f5a => 3
	i32 3624195450, ; 219: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 118
	i32 3641597786, ; 220: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 68
	i32 3643854240, ; 221: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 73
	i32 3647796983, ; 222: pt-BR/Microsoft.Maui.Controls.resources => 0xd96cf6f7 => 21
	i32 3657292374, ; 223: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 38
	i32 3660523487, ; 224: System.Net.NetworkInformation => 0xda2f27df => 104
	i32 3662115805, ; 225: he/Microsoft.Maui.Controls.resources => 0xda4773dd => 9
	i32 3672681054, ; 226: Mono.Android.dll => 0xdae8aa5e => 135
	i32 3686075795, ; 227: ms/Microsoft.Maui.Controls.resources => 0xdbb50d93 => 17
	i32 3697841164, ; 228: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3700866549, ; 229: System.Net.WebProxy.dll => 0xdc96bdf5 => 111
	i32 3724971120, ; 230: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 72
	i32 3732100267, ; 231: System.Net.NameResolution => 0xde7354ab => 103
	i32 3748608112, ; 232: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 94
	i32 3754567612, ; 233: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 54
	i32 3786282454, ; 234: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 60
	i32 3792276235, ; 235: System.Collections.NonGeneric => 0xe2098b0b => 86
	i32 3802395368, ; 236: System.Collections.Specialized.dll => 0xe2a3f2e8 => 87
	i32 3810220126, ; 237: HtmlAgilityPack.dll => 0xe31b585e => 35
	i32 3819260425, ; 238: System.Net.WebProxy => 0xe3a54a09 => 111
	i32 3823082795, ; 239: System.Security.Cryptography.dll => 0xe3df9d2b => 123
	i32 3827706314, ; 240: Jurassic.dll => 0xe42629ca => 36
	i32 3841636137, ; 241: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 40
	i32 3849253459, ; 242: System.Runtime.InteropServices.dll => 0xe56ef253 => 119
	i32 3876362041, ; 243: SQLite-net => 0xe70c9739 => 50
	i32 3885497537, ; 244: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 110
	i32 3889960447, ; 245: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 246: System.Collections.Concurrent.dll => 0xe839deed => 85
	i32 3896760992, ; 247: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 62
	i32 3928044579, ; 248: System.Xml.ReaderWriter => 0xea213423 => 128
	i32 3931092270, ; 249: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 75
	i32 3955647286, ; 250: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 57
	i32 3980434154, ; 251: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 252: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4025784931, ; 253: System.Memory => 0xeff49a63 => 101
	i32 4046471985, ; 254: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 46
	i32 4054681211, ; 255: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 116
	i32 4070331268, ; 256: id/Microsoft.Maui.Controls.resources => 0xf29c5384 => 13
	i32 4073602200, ; 257: System.Threading.dll => 0xf2ce3c98 => 127
	i32 4094352644, ; 258: Microsoft.Maui.Essentials.dll => 0xf40add04 => 48
	i32 4100113165, ; 259: System.Private.Uri => 0xf462c30d => 114
	i32 4102112229, ; 260: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4119206479, ; 261: pl/Microsoft.Maui.Controls.resources => 0xf5861a4f => 20
	i32 4125707920, ; 262: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 263: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 39
	i32 4147896353, ; 264: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 116
	i32 4151237749, ; 265: System.Core => 0xf76edc75 => 93
	i32 4182413190, ; 266: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 70
	i32 4213026141, ; 267: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 94
	i32 4234116406, ; 268: pt/Microsoft.Maui.Controls.resources => 0xfc5f7d36 => 22
	i32 4271975918, ; 269: Microsoft.Maui.Controls.dll => 0xfea12dee => 45
	i32 4274976490, ; 270: System.Runtime.Numerics => 0xfecef6ea => 121
	i32 4292120959 ; 271: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 70
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [272 x i32] [
	i32 104, ; 0
	i32 103, ; 1
	i32 126, ; 2
	i32 35, ; 3
	i32 1, ; 4
	i32 49, ; 5
	i32 31, ; 6
	i32 119, ; 7
	i32 125, ; 8
	i32 110, ; 9
	i32 60, ; 10
	i32 78, ; 11
	i32 30, ; 12
	i32 31, ; 13
	i32 91, ; 14
	i32 117, ; 15
	i32 2, ; 16
	i32 56, ; 17
	i32 15, ; 18
	i32 67, ; 19
	i32 53, ; 20
	i32 14, ; 21
	i32 2, ; 22
	i32 108, ; 23
	i32 126, ; 24
	i32 101, ; 25
	i32 55, ; 26
	i32 34, ; 27
	i32 26, ; 28
	i32 88, ; 29
	i32 66, ; 30
	i32 130, ; 31
	i32 129, ; 32
	i32 113, ; 33
	i32 13, ; 34
	i32 7, ; 35
	i32 44, ; 36
	i32 10, ; 37
	i32 41, ; 38
	i32 21, ; 39
	i32 64, ; 40
	i32 85, ; 41
	i32 107, ; 42
	i32 1, ; 43
	i32 16, ; 44
	i32 4, ; 45
	i32 120, ; 46
	i32 51, ; 47
	i32 106, ; 48
	i32 98, ; 49
	i32 43, ; 50
	i32 114, ; 51
	i32 97, ; 52
	i32 0, ; 53
	i32 89, ; 54
	i32 28, ; 55
	i32 67, ; 56
	i32 88, ; 57
	i32 32, ; 58
	i32 6, ; 59
	i32 77, ; 60
	i32 40, ; 61
	i32 3, ; 62
	i32 57, ; 63
	i32 99, ; 64
	i32 69, ; 65
	i32 90, ; 66
	i32 82, ; 67
	i32 129, ; 68
	i32 74, ; 69
	i32 7, ; 70
	i32 20, ; 71
	i32 18, ; 72
	i32 52, ; 73
	i32 65, ; 74
	i32 100, ; 75
	i32 77, ; 76
	i32 61, ; 77
	i32 96, ; 78
	i32 107, ; 79
	i32 98, ; 80
	i32 58, ; 81
	i32 44, ; 82
	i32 97, ; 83
	i32 10, ; 84
	i32 5, ; 85
	i32 124, ; 86
	i32 25, ; 87
	i32 8, ; 88
	i32 26, ; 89
	i32 33, ; 90
	i32 71, ; 91
	i32 80, ; 92
	i32 63, ; 93
	i32 102, ; 94
	i32 124, ; 95
	i32 122, ; 96
	i32 81, ; 97
	i32 105, ; 98
	i32 123, ; 99
	i32 53, ; 100
	i32 59, ; 101
	i32 23, ; 102
	i32 95, ; 103
	i32 78, ; 104
	i32 41, ; 105
	i32 93, ; 106
	i32 134, ; 107
	i32 66, ; 108
	i32 71, ; 109
	i32 18, ; 110
	i32 82, ; 111
	i32 81, ; 112
	i32 75, ; 113
	i32 12, ; 114
	i32 42, ; 115
	i32 29, ; 116
	i32 99, ; 117
	i32 86, ; 118
	i32 15, ; 119
	i32 37, ; 120
	i32 55, ; 121
	i32 11, ; 122
	i32 69, ; 123
	i32 0, ; 124
	i32 14, ; 125
	i32 115, ; 126
	i32 68, ; 127
	i32 95, ; 128
	i32 122, ; 129
	i32 112, ; 130
	i32 54, ; 131
	i32 92, ; 132
	i32 87, ; 133
	i32 16, ; 134
	i32 47, ; 135
	i32 23, ; 136
	i32 43, ; 137
	i32 42, ; 138
	i32 113, ; 139
	i32 83, ; 140
	i32 102, ; 141
	i32 36, ; 142
	i32 38, ; 143
	i32 8, ; 144
	i32 76, ; 145
	i32 27, ; 146
	i32 109, ; 147
	i32 132, ; 148
	i32 118, ; 149
	i32 105, ; 150
	i32 128, ; 151
	i32 28, ; 152
	i32 37, ; 153
	i32 19, ; 154
	i32 92, ; 155
	i32 109, ; 156
	i32 51, ; 157
	i32 131, ; 158
	i32 133, ; 159
	i32 45, ; 160
	i32 108, ; 161
	i32 25, ; 162
	i32 117, ; 163
	i32 83, ; 164
	i32 115, ; 165
	i32 63, ; 166
	i32 120, ; 167
	i32 121, ; 168
	i32 56, ; 169
	i32 125, ; 170
	i32 58, ; 171
	i32 46, ; 172
	i32 47, ; 173
	i32 79, ; 174
	i32 49, ; 175
	i32 29, ; 176
	i32 6, ; 177
	i32 61, ; 178
	i32 19, ; 179
	i32 79, ; 180
	i32 5, ; 181
	i32 48, ; 182
	i32 84, ; 183
	i32 24, ; 184
	i32 130, ; 185
	i32 132, ; 186
	i32 80, ; 187
	i32 112, ; 188
	i32 91, ; 189
	i32 65, ; 190
	i32 34, ; 191
	i32 72, ; 192
	i32 134, ; 193
	i32 89, ; 194
	i32 12, ; 195
	i32 96, ; 196
	i32 84, ; 197
	i32 73, ; 198
	i32 127, ; 199
	i32 59, ; 200
	i32 50, ; 201
	i32 106, ; 202
	i32 64, ; 203
	i32 74, ; 204
	i32 52, ; 205
	i32 62, ; 206
	i32 133, ; 207
	i32 76, ; 208
	i32 39, ; 209
	i32 131, ; 210
	i32 11, ; 211
	i32 90, ; 212
	i32 135, ; 213
	i32 24, ; 214
	i32 30, ; 215
	i32 4, ; 216
	i32 100, ; 217
	i32 3, ; 218
	i32 118, ; 219
	i32 68, ; 220
	i32 73, ; 221
	i32 21, ; 222
	i32 38, ; 223
	i32 104, ; 224
	i32 9, ; 225
	i32 135, ; 226
	i32 17, ; 227
	i32 33, ; 228
	i32 111, ; 229
	i32 72, ; 230
	i32 103, ; 231
	i32 94, ; 232
	i32 54, ; 233
	i32 60, ; 234
	i32 86, ; 235
	i32 87, ; 236
	i32 35, ; 237
	i32 111, ; 238
	i32 123, ; 239
	i32 36, ; 240
	i32 40, ; 241
	i32 119, ; 242
	i32 50, ; 243
	i32 110, ; 244
	i32 32, ; 245
	i32 85, ; 246
	i32 62, ; 247
	i32 128, ; 248
	i32 75, ; 249
	i32 57, ; 250
	i32 27, ; 251
	i32 9, ; 252
	i32 101, ; 253
	i32 46, ; 254
	i32 116, ; 255
	i32 13, ; 256
	i32 127, ; 257
	i32 48, ; 258
	i32 114, ; 259
	i32 22, ; 260
	i32 20, ; 261
	i32 17, ; 262
	i32 39, ; 263
	i32 116, ; 264
	i32 93, ; 265
	i32 70, ; 266
	i32 94, ; 267
	i32 22, ; 268
	i32 45, ; 269
	i32 121, ; 270
	i32 70 ; 271
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 96b6bb65e8736e45180905177aa343f0e1854ea3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
