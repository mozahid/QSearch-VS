.subsections_via_symbols
.section __DWARF, __debug_line,regular,debug
Ldebug_line_section_start:
Ldebug_line_start:
.section __DWARF, __debug_abbrev,regular,debug
Ldebug_abbrev_start:

	.byte 1,17,1,37,8,3,8,27,8,19,11,17,1,18,1,16,6,0,0,2,46,1,3,8,135,64,8,58,15,59,15,17
	.byte 1,18,1,64,10,0,0,3,5,0,3,8,73,19,2,10,0,0,15,5,0,3,8,73,19,2,6,0,0,4,36,0
	.byte 11,11,62,11,3,8,0,0,5,2,1,3,8,11,15,0,0,17,2,0,3,8,11,15,0,0,6,13,0,3,8,73
	.byte 19,56,10,0,0,7,22,0,3,8,73,19,0,0,8,4,1,3,8,11,15,73,19,0,0,9,40,0,3,8,28,13
	.byte 0,0,10,57,1,3,8,0,0,11,52,0,3,8,73,19,2,10,0,0,12,52,0,3,8,73,19,2,6,0,0,13
	.byte 15,0,73,19,0,0,14,16,0,73,19,0,0,16,28,0,73,19,56,10,0,0,18,46,0,3,8,17,1,18,1,0
	.byte 0,0
.section __DWARF, __debug_info,regular,debug
Ldebug_info_start:

LDIFF_SYM0=Ldebug_info_end - Ldebug_info_begin
	.long LDIFF_SYM0
Ldebug_info_begin:

	.short 2
	.long 0
	.byte 8,1
	.asciz "Mono AOT Compiler 8.0.18.0 (8.0.1825.31117 @Commit: ef853a71052646a42abf17e888ec6d9a69614ad9)"
	.asciz "System.Security.Cryptography.dll"
	.asciz ""

	.byte 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
LDIFF_SYM1=Ldebug_line_start - Ldebug_line_section_start
	.long LDIFF_SYM1
LDIE_I1:

	.byte 4,1,5
	.asciz "sbyte"
LDIE_U1:

	.byte 4,1,7
	.asciz "byte"
LDIE_I2:

	.byte 4,2,5
	.asciz "short"
LDIE_U2:

	.byte 4,2,7
	.asciz "ushort"
LDIE_I4:

	.byte 4,4,5
	.asciz "int"
LDIE_U4:

	.byte 4,4,7
	.asciz "uint"
LDIE_I8:

	.byte 4,8,5
	.asciz "long"
LDIE_U8:

	.byte 4,8,7
	.asciz "ulong"
LDIE_I:

	.byte 4,8,5
	.asciz "intptr"
LDIE_U:

	.byte 4,8,7
	.asciz "uintptr"
LDIE_R4:

	.byte 4,4,4
	.asciz "float"
LDIE_R8:

	.byte 4,8,4
	.asciz "double"
LDIE_BOOLEAN:

	.byte 4,1,2
	.asciz "boolean"
LDIE_CHAR:

	.byte 4,2,8
	.asciz "char"
LDIE_STRING:

	.byte 4,8,1
	.asciz "string"
LDIE_OBJECT:

	.byte 4,8,1
	.asciz "object"
LDIE_SZARRAY:

	.byte 4,8,1
	.asciz "object"
.section __DWARF, __debug_loc,regular,debug
Ldebug_loc_start:
.section __DWARF, __debug_frame,regular,debug
	.align 3

LDIFF_SYM2=Lcie0_end - Lcie0_start
	.long LDIFF_SYM2
Lcie0_start:

	.long -1
	.byte 3
	.asciz ""

	.byte 1,120,30
	.align 3
Lcie0_end:
.text
	.align 3
jit_code_start:
_mono_aot_System_Security_Cryptographyjit_code_start:
	.globl _mono_aot_System_Security_Cryptographyjit_code_start

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
.text
	.align 4
	.no_dead_strip Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_
Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_:
.file 1 "<unknown>"
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xf9000fa0
.word 0xaa0103fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0x3900c3bf
.word 0xd2800000
.word 0xf90013a0
.word 0xf90017a0
.word 0xf9001fbf
.word 0xd2a00000
.word 0x3900c3a0

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #192]
.word 0x910083a0
bl _p_54
.word 0xf9001fba
.word 0xf9401fba
.word 0xb9801ba0
.word 0xaa1a03e1
bl _p_55
.word 0xaa0003fa
.word 0xf90023bf
.word 0x94000005
.word 0xf94023a0
.word 0xb4000040
bl _p_7
.word 0x1400000d
.word 0xf9002bbe

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0xd2a00000
.word 0x2a0003e0
.word 0xf9001fa0
.word 0xf9402bbe
.word 0xd61f03c0
.word 0xd2800020
.word 0x3900c3a0

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #200]
.word 0x910083a0
.word 0xaa1a03e1
bl _p_56
.word 0xf94017ba
.word 0xf90027bf
.word 0x94000005
.word 0xf94027a0
.word 0xb4000040
bl _p_7
.word 0x14000011
.word 0xf90033be

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0x3940c3a0
.word 0x340000c0

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #208]
.word 0x910083a0
bl _p_57
.word 0xf94033be
.word 0xd61f03c0
.word 0xaa1a03e0
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_1:
.text
	.align 4
	.no_dead_strip Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xf90017a0
.word 0xf9001ba1
.word 0xf9001fa2

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0
.word 0xf9002bbf
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #216]
.word 0x910103a0
.word 0xf94017a1
bl _p_4
.word 0xf9401ba0
.word 0xf9002ba0
.word 0xf9402bb9
.word 0xf94027a0
.word 0xaa0003e1
.word 0x3940003e
.word 0xf9400818
.word 0xaa1803e0
.word 0xaa1903e1
.word 0xb9803ba2
bl _p_58
.word 0x93407c00
.word 0xaa0003fa
.word 0xf9002fbf
.word 0x9400000a
.word 0xf9402fa0
.word 0xb4000040
bl _p_7
.word 0xf90033bf
.word 0x94000011
.word 0xf94033a0
.word 0xb4000040
bl _p_7
.word 0x1400001b
.word 0xf90037be

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0xd2a00000
.word 0x2a0003e0
.word 0xf9002ba0
.word 0xf94037be
.word 0xd61f03c0
.word 0xf9003fbe

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #224]
.word 0x910103a0
bl _p_8
.word 0xf9403fbe
.word 0xd61f03c0
.word 0xaa1a03e0
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_3:
.text
	.align 4
	.no_dead_strip Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xf90017a0
.word 0xf9001ba1
.word 0xf9001fa2

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0
.word 0xf9002bbf
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #216]
.word 0x910103a0
.word 0xf94017a1
bl _p_4
.word 0xf9401ba0
.word 0xf9002ba0
.word 0xf9402bb9
.word 0xf94027a0
.word 0xaa0003e1
.word 0x3940003e
.word 0xf9400818
.word 0xaa1803e0
.word 0xaa1903e1
.word 0xb9803ba2
bl _p_59
.word 0x93407c00
.word 0xaa0003fa
.word 0xf9002fbf
.word 0x9400000a
.word 0xf9402fa0
.word 0xb4000040
bl _p_7
.word 0xf90033bf
.word 0x94000011
.word 0xf94033a0
.word 0xb4000040
bl _p_7
.word 0x1400001b
.word 0xf90037be

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1
.word 0xd2a00000
.word 0x2a0003e0
.word 0xf9002ba0
.word 0xf94037be
.word 0xd61f03c0
.word 0xf9003fbe

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x15, [x16, #224]
.word 0x910103a0
bl _p_8
.word 0xf9403fbe
.word 0xd61f03c0
.word 0xaa1a03e0
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_5:
.text
ut_47:
add x0, x0, 16
b _System_Security_Cryptography_System_Security_Cryptography_LiteHash_get_HashSizeInBytes
ut_end:
.section __TEXT, __const
_unbox_trampoline_p:

	.long 0
LDIFF_SYM3=ut_end - ut_47
	.long LDIFF_SYM3
.text
ut_48:
add x0, x0, 16
b _System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm
.text
ut_49:
add x0, x0, 16
b _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte
.text
ut_50:
add x0, x0, 16
b _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte
.text
ut_51:
add x0, x0, 16
b _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset
.text
ut_52:
add x0, x0, 16
b _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose
.text
ut_60:
add x0, x0, 16
b _System_Security_Cryptography_wrapper_other_System_ReadOnlySpan_1_byte_StructureToPtr_object_intptr_bool
.text
ut_61:
add x0, x0, 16
b _System_Security_Cryptography_wrapper_other_System_ReadOnlySpan_1_byte_PtrToStructure_intptr_object
.text
ut_62:
add x0, x0, 16
b _System_Security_Cryptography_wrapper_other_System_Span_1_byte_StructureToPtr_object_intptr_bool
.text
ut_63:
add x0, x0, 16
b _System_Security_Cryptography_wrapper_other_System_Span_1_byte_PtrToStructure_intptr_object
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr
wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9001bbe
.word 0xa903d3b3
.word 0xa904dbb5
.word 0xa905e3b7
.word 0xa906ebb9
.word 0xa907f3bb
.word 0xf90047bd
.word 0x910003f1
.word 0xf9004bb1
.word 0xaa0003fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xaa0003f9
.word 0x910083a0
.word 0xf9400321
.word 0xf90013a1
.word 0xf9000320
.word 0x910063a0
bl _mono_threads_enter_gc_safe_region_unbalanced
.word 0xf90053a0
.word 0xaa1a03e0
bl _AppleCryptoNative_DigestFree
.word 0xf94053a0
.word 0x910043a1
bl _mono_threads_exit_gc_safe_region_unbalanced

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #48]
.word 0xb9400000
.word 0x350001a0
.word 0x14000001
.word 0xf94013a0
.word 0xf9000320
.word 0xa946ebb9
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0x91022340
.word 0xd280003e
.word 0xb900001e
.word 0xaa1a03e0
bl _p_52
bl _p_51
.word 0xaa0003fa
.word 0xb5ffff20
.word 0x17fffff2

Lme_40:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_
wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9001bbe
.word 0xa903d3b3
.word 0xa904dbb5
.word 0xa905e3b7
.word 0xa906ebb9
.word 0xa907f3bb
.word 0xf90047bd
.word 0x910003f1
.word 0xf9004bb1
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xaa0003f8
.word 0x910083a0
.word 0xf9400301
.word 0xf90013a1
.word 0xf9000300
.word 0x910063a0
bl _mono_threads_enter_gc_safe_region_unbalanced
.word 0xf90057a0
.word 0xaa1903e0
.word 0xaa1a03e1
bl _AppleCryptoNative_DigestCreate
.word 0xaa0003e1
.word 0xf94057a0
.word 0xf90053a1
.word 0x910043a1
bl _mono_threads_exit_gc_safe_region_unbalanced
.word 0xf94053a0
.word 0xaa0003fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #48]
.word 0xb9400000
.word 0x350001e0
.word 0x14000001
.word 0xf94013a0
.word 0xf9000300
.word 0xaa1a03e0
.word 0xa94667b8
.word 0xf9403bba
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0x91022320
.word 0xd280003e
.word 0xb900001e
.word 0xaa1903e0
bl _p_52
bl _p_51
.word 0xaa0003f9
.word 0xb5ffff20
.word 0x17fffff0

Lme_41:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int
wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9001fbe
.word 0xa90453b3
.word 0xa9055bb5
.word 0xa90663b7
.word 0xa9076bb9
.word 0xa90873bb
.word 0xf9004bbd
.word 0x910003f1
.word 0xf9004fb1
.word 0xf9000ba0
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xaa0003f7
.word 0x9100a3a0
.word 0xf94002e1
.word 0xf90017a1
.word 0xf90002e0
.word 0x910083a0
bl _mono_threads_enter_gc_safe_region_unbalanced
.word 0xf90057a0
.word 0xf9400ba0
.word 0xaa1903e1
.word 0xaa1a03e2
bl _AppleCryptoNative_DigestUpdate
.word 0x93407c00
.word 0xaa0003e1
.word 0xf94057a0
.word 0xf90053a1
.word 0x910063a1
bl _mono_threads_exit_gc_safe_region_unbalanced
.word 0xf94053a0
.word 0xaa0003fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #48]
.word 0xb9400000
.word 0x350001e0
.word 0x14000001
.word 0xf94017a0
.word 0xf90002e0
.word 0xaa1a03e0
.word 0xf94033b7
.word 0xa9476bb9
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0x91022320
.word 0xd280003e
.word 0xb900001e
.word 0xaa1903e0
bl _p_52
bl _p_51
.word 0xaa0003f9
.word 0xb5ffff20
.word 0x17fffff0

Lme_42:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int
wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9001fbe
.word 0xa90453b3
.word 0xa9055bb5
.word 0xa90663b7
.word 0xa9076bb9
.word 0xa90873bb
.word 0xf9004bbd
.word 0x910003f1
.word 0xf9004fb1
.word 0xf9000ba0
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xaa0003f7
.word 0x9100a3a0
.word 0xf94002e1
.word 0xf90017a1
.word 0xf90002e0
.word 0x910083a0
bl _mono_threads_enter_gc_safe_region_unbalanced
.word 0xf90057a0
.word 0xf9400ba0
.word 0xaa1903e1
.word 0xaa1a03e2
bl _AppleCryptoNative_DigestFinal
.word 0x93407c00
.word 0xaa0003e1
.word 0xf94057a0
.word 0xf90053a1
.word 0x910063a1
bl _mono_threads_exit_gc_safe_region_unbalanced
.word 0xf94053a0
.word 0xaa0003fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #48]
.word 0xb9400000
.word 0x350001e0
.word 0x14000001
.word 0xf94017a0
.word 0xf90002e0
.word 0xaa1a03e0
.word 0xf94033b7
.word 0xa9476bb9
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0x91022320
.word 0xd280003e
.word 0xb900001e
.word 0xaa1903e0
bl _p_52
bl _p_51
.word 0xaa0003f9
.word 0xb5ffff20
.word 0x17fffff0

Lme_43:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr
wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9001bbe
.word 0xa903d3b3
.word 0xa904dbb5
.word 0xa905e3b7
.word 0xa906ebb9
.word 0xa907f3bb
.word 0xf90047bd
.word 0x910003f1
.word 0xf9004bb1
.word 0xaa0003fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #56]
.word 0xf9400011
.word 0xb4000051
bl _p_1

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xaa0003f9
.word 0x910083a0
.word 0xf9400321
.word 0xf90013a1
.word 0xf9000320
.word 0x910063a0
bl _mono_threads_enter_gc_safe_region_unbalanced
.word 0xf90057a0
.word 0xaa1a03e0
bl _AppleCryptoNative_DigestReset
.word 0x93407c00
.word 0xaa0003e1
.word 0xf94057a0
.word 0xf90053a1
.word 0x910043a1
bl _mono_threads_exit_gc_safe_region_unbalanced
.word 0xf94053a0
.word 0xaa0003fa

adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x0, [x16, #48]
.word 0xb9400000
.word 0x350001e0
.word 0x14000001
.word 0xf94013a0
.word 0xf9000320
.word 0xaa1a03e0
.word 0xa94667b8
.word 0xf9403bba
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0x91022300
.word 0xd280003e
.word 0xb900001e
.word 0xaa1803e0
bl _p_52
bl _p_51
.word 0xaa0003f8
.word 0xb5ffff20
.word 0x17fffff0

Lme_44:
.text
	.align 3
jit_code_end:
_mono_aot_System_Security_Cryptographyjit_code_end:
	.globl _mono_aot_System_Security_Cryptographyjit_code_end

	.byte 0,0,0,0
.no_dead_strip _System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte
.no_dead_strip _System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte
.no_dead_strip _System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle
.no_dead_strip _System_Security_Cryptography_System_SR_Format_string_object
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm__ctor
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_ComputeHash_byte__
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_ComputeHash_System_IO_Stream
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_Dispose
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_Dispose_bool
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProvider_Dispose
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProvider__ctor
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5__ctor
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5_Create
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_HashCore_byte___int_int
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_HashFinal
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_Initialize
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_Dispose_bool
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_AppendHashData_System_ReadOnlySpan_1_byte
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_FinalizeHashAndReset_System_Span_1_byte
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_get_HashSizeInBytes
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_Dispose_bool
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_Reset
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHash_get_HashSizeInBytes
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_Apple_SafeDigestCtxHandle_ReleaseHandle
.no_dead_strip _System_Security_Cryptography_System_Security_Cryptography_Apple_SafeDigestCtxHandle_get_IsInvalid
.no_dead_strip _System_Security_Cryptography_wrapper_delegate_invoke_System_Runtime_CompilerServices_ConditionalWeakTable_2_CreateValueCallback_TKey_REF_TValue_REF_invoke_TValue_TKey_TKey_REF
.no_dead_strip _System_Security_Cryptography_wrapper_runtime_invoke__Module_runtime_invoke_byte__this___int_object_intptr_intptr_intptr
.no_dead_strip _System_Security_Cryptography_wrapper_runtime_invoke__Module_runtime_invoke_void__this___int_byte_object_intptr_intptr_intptr
.no_dead_strip _System_Security_Cryptography_wrapper_other_System_ReadOnlySpan_1_byte_StructureToPtr_object_intptr_bool
.no_dead_strip _System_Security_Cryptography_wrapper_other_System_ReadOnlySpan_1_byte_PtrToStructure_intptr_object
.no_dead_strip _System_Security_Cryptography_wrapper_other_System_Span_1_byte_StructureToPtr_object_intptr_bool
.no_dead_strip _System_Security_Cryptography_wrapper_other_System_Span_1_byte_PtrToStructure_intptr_object
.no_dead_strip _mono_aot_System_Security_Cryptography_init_method
.no_dead_strip _mono_aot_System_Security_Cryptography_init_method_gshared_mrgctx
.no_dead_strip _mono_aot_System_Security_Cryptography_init_method_gshared_this
.no_dead_strip _mono_aot_System_Security_Cryptography_init_method_gshared_vtable
.no_dead_strip _mono_aot_System_Security_Cryptography_icall_cold_wrapper_264

.text
	.align 3
method_addresses:
_mono_aot_System_Security_Cryptographymethod_addresses:
	.globl _mono_aot_System_Security_Cryptographymethod_addresses
	.no_dead_strip method_addresses
bl method_addresses
bl Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_
bl _System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte
bl Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
bl _System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte
bl Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
bl _System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl _System_Security_Cryptography_System_SR_Format_string_object
bl _System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm__ctor
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_ComputeHash_byte__
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_ComputeHash_System_IO_Stream
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_Dispose
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_Dispose_bool
bl method_addresses
bl method_addresses
bl method_addresses
bl _System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string
bl _System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int
bl method_addresses
bl method_addresses
bl _System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset
bl method_addresses
bl _System_Security_Cryptography_System_Security_Cryptography_HashProvider_Dispose
bl method_addresses
bl method_addresses
bl _System_Security_Cryptography_System_Security_Cryptography_HashProvider__ctor
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string
bl _System_Security_Cryptography_System_Security_Cryptography_MD5__ctor
bl _System_Security_Cryptography_System_Security_Cryptography_MD5_Create
bl _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor
bl _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_HashCore_byte___int_int
bl _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_HashFinal
bl _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_Initialize
bl _System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation_Dispose_bool
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_AppendHashData_System_ReadOnlySpan_1_byte
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_FinalizeHashAndReset_System_Span_1_byte
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_get_HashSizeInBytes
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_Dispose_bool
bl _System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider_Reset
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHash_get_HashSizeInBytes
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset
bl _System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose
bl _System_Security_Cryptography_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor
bl _System_Security_Cryptography_System_Security_Cryptography_Apple_SafeDigestCtxHandle_ReleaseHandle
bl _System_Security_Cryptography_System_Security_Cryptography_Apple_SafeDigestCtxHandle_get_IsInvalid
bl method_addresses
bl _System_Security_Cryptography_wrapper_delegate_invoke_System_Runtime_CompilerServices_ConditionalWeakTable_2_CreateValueCallback_TKey_REF_TValue_REF_invoke_TValue_TKey_TKey_REF
bl _System_Security_Cryptography_wrapper_runtime_invoke__Module_runtime_invoke_byte__this___int_object_intptr_intptr_intptr
bl _System_Security_Cryptography_wrapper_runtime_invoke__Module_runtime_invoke_void__this___int_byte_object_intptr_intptr_intptr
bl _System_Security_Cryptography_wrapper_other_System_ReadOnlySpan_1_byte_StructureToPtr_object_intptr_bool
bl _System_Security_Cryptography_wrapper_other_System_ReadOnlySpan_1_byte_PtrToStructure_intptr_object
bl _System_Security_Cryptography_wrapper_other_System_Span_1_byte_StructureToPtr_object_intptr_bool
bl _System_Security_Cryptography_wrapper_other_System_Span_1_byte_PtrToStructure_intptr_object
bl wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr
bl wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_
bl wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int
bl wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int
bl wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr
bl _mono_aot_System_Security_Cryptography_init_method
bl _mono_aot_System_Security_Cryptography_init_method_gshared_mrgctx
bl _mono_aot_System_Security_Cryptography_init_method_gshared_this
bl _mono_aot_System_Security_Cryptography_init_method_gshared_vtable
bl _mono_aot_System_Security_Cryptography_icall_cold_wrapper_264
bl method_addresses
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:
_mono_aot_System_Security_Cryptographyunbox_trampolines:
	.globl _mono_aot_System_Security_Cryptographyunbox_trampolines

	.long 47,48,49,50,51,52,60,61
	.long 62,63
unbox_trampolines_end:
_mono_aot_System_Security_Cryptographyunbox_trampolines_end:
	.globl _mono_aot_System_Security_Cryptographyunbox_trampolines_end

	.long 0
.text
	.align 3
unbox_trampoline_addresses:
_mono_aot_System_Security_Cryptographyunbox_trampoline_addresses:
	.globl _mono_aot_System_Security_Cryptographyunbox_trampoline_addresses
bl ut_47
bl ut_48
bl ut_49
bl ut_50
bl ut_51
bl ut_52
bl ut_60
bl ut_61
bl ut_62
bl ut_63

	.long 0
.section __TEXT, __const
	.align 3
unwind_info:
_mono_aot_System_Security_Cryptographyunwind_info:
	.globl _mono_aot_System_Security_Cryptographyunwind_info

	.byte 0,16,12,31,0,68,14,112,157,14,158,13,68,13,29,68,154,12,22,12,31,0,68,14,144,1,157,18,158,17,68,13
	.byte 29,68,152,16,153,15,68,154,14,39,12,31,0,68,14,176,1,157,22,158,21,68,13,29,76,147,15,148,14,68,149,13
	.byte 150,12,68,151,11,152,10,68,153,9,154,8,68,155,7,156,6,39,12,31,0,68,14,176,1,157,22,158,21,68,13,29
	.byte 76,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8,154,7,68,155,6,156,5

.text
	.align 4
plt:
_mono_aot_System_Security_Cryptographyplt:
	.globl _mono_aot_System_Security_Cryptographyplt
mono_aot_System_Security_Cryptography_plt:
_p_1_plt_System_Security_Cryptography__jit_icall_mono_threads_state_poll_llvm:
	.globl _p_1_plt_System_Security_Cryptography__jit_icall_mono_threads_state_poll_llvm
.private_extern _p_1_plt_System_Security_Cryptography__jit_icall_mono_threads_state_poll_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_threads_state_poll
plt_System_Security_Cryptography__jit_icall_mono_threads_state_poll:
_p_1:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #240]
br x16
.word 357
_p_2_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int_llvm:
	.globl _p_2_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int_llvm
.private_extern _p_2_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int:
_p_2:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #248]
br x16
.word 360
_p_3_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int_llvm:
	.globl _p_3_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int_llvm
.private_extern _p_3_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int:
_p_3:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #256]
br x16
.word 365
_p_4_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromManaged_System_Security_Cryptography_Apple_SafeDigestCtxHandle_llvm:
	.globl _p_4_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromManaged_System_Security_Cryptography_Apple_SafeDigestCtxHandle_llvm
.private_extern _p_4_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromManaged_System_Security_Cryptography_Apple_SafeDigestCtxHandle_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromManaged_System_Security_Cryptography_Apple_SafeDigestCtxHandle
plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromManaged_System_Security_Cryptography_Apple_SafeDigestCtxHandle:
_p_4:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #264]
br x16
.word 370
_p_5_plt_System_Security_Cryptography__jit_icall_llvm_throw_corlib_exception_abs_trampoline_llvm:
	.globl _p_5_plt_System_Security_Cryptography__jit_icall_llvm_throw_corlib_exception_abs_trampoline_llvm
.private_extern _p_5_plt_System_Security_Cryptography__jit_icall_llvm_throw_corlib_exception_abs_trampoline_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_llvm_throw_corlib_exception_abs_trampoline
plt_System_Security_Cryptography__jit_icall_llvm_throw_corlib_exception_abs_trampoline:
_p_5:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #272]
br x16
.word 381
_p_6_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr_llvm:
	.globl _p_6_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr_llvm
.private_extern _p_6_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr
plt_System_Security_Cryptography_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr:
_p_6:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #280]
br x16
.word 384
_p_7_plt_System_Security_Cryptography__jit_icall_ves_icall_thread_finish_async_abort_llvm:
	.globl _p_7_plt_System_Security_Cryptography__jit_icall_ves_icall_thread_finish_async_abort_llvm
.private_extern _p_7_plt_System_Security_Cryptography__jit_icall_ves_icall_thread_finish_async_abort_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_ves_icall_thread_finish_async_abort
plt_System_Security_Cryptography__jit_icall_ves_icall_thread_finish_async_abort:
_p_7:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #288]
br x16
.word 389
_p_8_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free_llvm:
	.globl _p_8_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free_llvm
.private_extern _p_8_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free
plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedIn_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free:
_p_8:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #296]
br x16
.word 392
_p_9_plt_System_Security_Cryptography__jit_icall_llvm_resume_unwind_trampoline_llvm:
	.globl _p_9_plt_System_Security_Cryptography__jit_icall_llvm_resume_unwind_trampoline_llvm
.private_extern _p_9_plt_System_Security_Cryptography__jit_icall_llvm_resume_unwind_trampoline_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_llvm_resume_unwind_trampoline
plt_System_Security_Cryptography__jit_icall_llvm_resume_unwind_trampoline:
_p_9:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #304]
br x16
.word 403
_p_10_plt_System_Security_Cryptography_wrapper_alloc_object_AllocVector_intptr_intptr_llvm:
	.globl _p_10_plt_System_Security_Cryptography_wrapper_alloc_object_AllocVector_intptr_intptr_llvm
.private_extern _p_10_plt_System_Security_Cryptography_wrapper_alloc_object_AllocVector_intptr_intptr_llvm
	.no_dead_strip plt_System_Security_Cryptography_wrapper_alloc_object_AllocVector_intptr_intptr
plt_System_Security_Cryptography_wrapper_alloc_object_AllocVector_intptr_intptr:
_p_10:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #312]
br x16
.word 406
_p_11_plt_System_Security_Cryptography_string_Join_string_object___llvm:
	.globl _p_11_plt_System_Security_Cryptography_string_Join_string_object___llvm
.private_extern _p_11_plt_System_Security_Cryptography_string_Join_string_object___llvm
	.no_dead_strip plt_System_Security_Cryptography_string_Join_string_object__
plt_System_Security_Cryptography_string_Join_string_object__:
_p_11:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #320]
br x16
.word 414
_p_12_plt_System_Security_Cryptography_System_Span_1_byte_Clear_llvm:
	.globl _p_12_plt_System_Security_Cryptography_System_Span_1_byte_Clear_llvm
.private_extern _p_12_plt_System_Security_Cryptography_System_Span_1_byte_Clear_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Span_1_byte_Clear
plt_System_Security_Cryptography_System_Span_1_byte_Clear:
_p_12:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #328]
br x16
.word 417
_p_13_plt_System_Security_Cryptography_System_ArgumentNullException_ThrowIfNull_object_string_llvm:
	.globl _p_13_plt_System_Security_Cryptography_System_ArgumentNullException_ThrowIfNull_object_string_llvm
.private_extern _p_13_plt_System_Security_Cryptography_System_ArgumentNullException_ThrowIfNull_object_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_ArgumentNullException_ThrowIfNull_object_string
plt_System_Security_Cryptography_System_ArgumentNullException_ThrowIfNull_object_string:
_p_13:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #336]
br x16
.word 428
_p_14_plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize_llvm:
	.globl _p_14_plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize_llvm
.private_extern _p_14_plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize
plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithm_CaptureHashCodeAndReinitialize:
_p_14:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #344]
br x16
.word 431
_p_15_plt_System_Security_Cryptography_System_ThrowHelper_ThrowObjectDisposedException_object_llvm:
	.globl _p_15_plt_System_Security_Cryptography_System_ThrowHelper_ThrowObjectDisposedException_object_llvm
.private_extern _p_15_plt_System_Security_Cryptography_System_ThrowHelper_ThrowObjectDisposedException_object_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_ThrowHelper_ThrowObjectDisposedException_object
plt_System_Security_Cryptography_System_ThrowHelper_ThrowObjectDisposedException_object:
_p_15:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #352]
br x16
.word 436
_p_16_plt_System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte_llvm:
	.globl _p_16_plt_System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte_llvm
.private_extern _p_16_plt_System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte
plt_System_Security_Cryptography_System_Security_Cryptography_CryptographicOperations_ZeroMemory_System_Span_1_byte:
_p_16:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #360]
br x16
.word 439
_p_17_plt_System_Security_Cryptography__jit_icall_mono_generic_class_init_llvm:
	.globl _p_17_plt_System_Security_Cryptography__jit_icall_mono_generic_class_init_llvm
.private_extern _p_17_plt_System_Security_Cryptography__jit_icall_mono_generic_class_init_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_generic_class_init
plt_System_Security_Cryptography__jit_icall_mono_generic_class_init:
_p_17:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #368]
br x16
.word 444
_p_18_plt_System_Security_Cryptography_System_ThrowHelper_ThrowArgumentOutOfRangeException_llvm:
	.globl _p_18_plt_System_Security_Cryptography_System_ThrowHelper_ThrowArgumentOutOfRangeException_llvm
.private_extern _p_18_plt_System_Security_Cryptography_System_ThrowHelper_ThrowArgumentOutOfRangeException_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_ThrowHelper_ThrowArgumentOutOfRangeException
plt_System_Security_Cryptography_System_ThrowHelper_ThrowArgumentOutOfRangeException:
_p_18:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #376]
br x16
.word 447
_p_19_plt_System_Security_Cryptography_System_ThrowHelper_ThrowArrayTypeMismatchException_llvm:
	.globl _p_19_plt_System_Security_Cryptography_System_ThrowHelper_ThrowArrayTypeMismatchException_llvm
.private_extern _p_19_plt_System_Security_Cryptography_System_ThrowHelper_ThrowArrayTypeMismatchException_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_ThrowHelper_ThrowArrayTypeMismatchException
plt_System_Security_Cryptography_System_ThrowHelper_ThrowArrayTypeMismatchException:
_p_19:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #384]
br x16
.word 450
_p_20_plt_System_Security_Cryptography_System_Array_Clone_llvm:
	.globl _p_20_plt_System_Security_Cryptography_System_Array_Clone_llvm
.private_extern _p_20_plt_System_Security_Cryptography_System_Array_Clone_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Array_Clone
plt_System_Security_Cryptography_System_Array_Clone:
_p_20:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #392]
br x16
.word 453
_p_21_plt_System_Security_Cryptography_System_GC_SuppressFinalize_object_llvm:
	.globl _p_21_plt_System_Security_Cryptography_System_GC_SuppressFinalize_object_llvm
.private_extern _p_21_plt_System_Security_Cryptography_System_GC_SuppressFinalize_object_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_GC_SuppressFinalize_object
plt_System_Security_Cryptography_System_GC_SuppressFinalize_object:
_p_21:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #400]
br x16
.word 456
_p_22_plt_System_Security_Cryptography_string_op_Equality_string_string_llvm:
	.globl _p_22_plt_System_Security_Cryptography_string_op_Equality_string_string_llvm
.private_extern _p_22_plt_System_Security_Cryptography_string_op_Equality_string_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_string_op_Equality_string_string
plt_System_Security_Cryptography_string_op_Equality_string_string:
_p_22:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #408]
br x16
.word 459
_p_23_plt_System_Security_Cryptography__jit_icall_mono_helper_ldstr_llvm:
	.globl _p_23_plt_System_Security_Cryptography__jit_icall_mono_helper_ldstr_llvm
.private_extern _p_23_plt_System_Security_Cryptography__jit_icall_mono_helper_ldstr_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_helper_ldstr
plt_System_Security_Cryptography__jit_icall_mono_helper_ldstr:
_p_23:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #416]
br x16
.word 462
_p_24_plt_System_Security_Cryptography_System_SR_Format_string_object_llvm:
	.globl _p_24_plt_System_Security_Cryptography_System_SR_Format_string_object_llvm
.private_extern _p_24_plt_System_Security_Cryptography_System_SR_Format_string_object_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_SR_Format_string_object
plt_System_Security_Cryptography_System_SR_Format_string_object:
_p_24:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #424]
br x16
.word 465
_p_25_plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_1_llvm:
	.globl _p_25_plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_1_llvm
.private_extern _p_25_plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_1_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_1
plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_1:
_p_25:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #432]
br x16
.word 470
_p_26_plt_System_Security_Cryptography__jit_icall_mono_arch_throw_exception_llvm:
	.globl _p_26_plt_System_Security_Cryptography__jit_icall_mono_arch_throw_exception_llvm
.private_extern _p_26_plt_System_Security_Cryptography__jit_icall_mono_arch_throw_exception_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_arch_throw_exception
plt_System_Security_Cryptography__jit_icall_mono_arch_throw_exception:
_p_26:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #440]
br x16
.word 473
_p_27_plt_System_Security_Cryptography_System_ArgumentOutOfRangeException_ThrowIfNegative_int_int_string_llvm:
	.globl _p_27_plt_System_Security_Cryptography_System_ArgumentOutOfRangeException_ThrowIfNegative_int_int_string_llvm
.private_extern _p_27_plt_System_Security_Cryptography_System_ArgumentOutOfRangeException_ThrowIfNegative_int_int_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_ArgumentOutOfRangeException_ThrowIfNegative_int_int_string
plt_System_Security_Cryptography_System_ArgumentOutOfRangeException_ThrowIfNegative_int_int_string:
_p_27:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #448]
br x16
.word 475
_p_28_plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string_llvm:
	.globl _p_28_plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string_llvm
.private_extern _p_28_plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string
plt_System_Security_Cryptography_System_Security_Cryptography_HashAlgorithmNames_HashAlgorithmToPal_string:
_p_28:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #456]
br x16
.word 487
_p_29_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm_llvm:
	.globl _p_29_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm_llvm
.private_extern _p_29_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm
plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash__ctor_Interop_AppleCrypto_PAL_HashAlgorithm:
_p_29:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #464]
br x16
.word 492
_p_30_plt_System_Security_Cryptography_wrapper_alloc_object_AllocSmall_intptr_intptr_llvm:
	.globl _p_30_plt_System_Security_Cryptography_wrapper_alloc_object_AllocSmall_intptr_intptr_llvm
.private_extern _p_30_plt_System_Security_Cryptography_wrapper_alloc_object_AllocSmall_intptr_intptr_llvm
	.no_dead_strip plt_System_Security_Cryptography_wrapper_alloc_object_AllocSmall_intptr_intptr
plt_System_Security_Cryptography_wrapper_alloc_object_AllocSmall_intptr_intptr:
_p_30:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #472]
br x16
.word 497
_p_31_plt_System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor_llvm:
	.globl _p_31_plt_System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor_llvm
.private_extern _p_31_plt_System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor
plt_System_Security_Cryptography_System_Security_Cryptography_MD5_Implementation__ctor:
_p_31:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #480]
br x16
.word 505
_p_32_plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string_llvm:
	.globl _p_32_plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string_llvm
.private_extern _p_32_plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string
plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_CreateHashProvider_string:
_p_32:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #488]
br x16
.word 510
_p_33_plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int_llvm:
	.globl _p_33_plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int_llvm
.private_extern _p_33_plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int
plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_AppendHashData_byte___int_int:
_p_33:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #496]
br x16
.word 515
_p_34_plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset_llvm:
	.globl _p_34_plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset_llvm
.private_extern _p_34_plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset
plt_System_Security_Cryptography_System_Security_Cryptography_HashProvider_FinalizeHashAndReset:
_p_34:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #504]
br x16
.word 520
_p_35_plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string_llvm:
	.globl _p_35_plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string_llvm
.private_extern _p_35_plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string
plt_System_Security_Cryptography_System_Security_Cryptography_HashProviderDispenser_AppleDigestProvider__ctor_string:
_p_35:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #512]
br x16
.word 525
_p_36_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string_llvm:
	.globl _p_36_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string_llvm
.private_extern _p_36_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string
plt_System_Security_Cryptography_System_Security_Cryptography_LiteHashProvider_CreateHash_string:
_p_36:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #520]
br x16
.word 530
_p_37_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte_llvm:
	.globl _p_37_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte_llvm
.private_extern _p_37_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte
plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Append_System_ReadOnlySpan_1_byte:
_p_37:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #528]
br x16
.word 535
_p_38_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte_llvm:
	.globl _p_38_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte_llvm
.private_extern _p_38_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte
plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Finalize_System_Span_1_byte:
_p_38:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #536]
br x16
.word 540
_p_39_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose_llvm:
	.globl _p_39_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose_llvm
.private_extern _p_39_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose
plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Dispose:
_p_39:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #544]
br x16
.word 545
_p_40_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset_llvm:
	.globl _p_40_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset_llvm
.private_extern _p_40_plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset
plt_System_Security_Cryptography_System_Security_Cryptography_LiteHash_Reset:
_p_40:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #552]
br x16
.word 550
_p_41_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int__llvm:
	.globl _p_41_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int__llvm
.private_extern _p_41_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int__llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_:
_p_41:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #560]
br x16
.word 555
_p_42_plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle_Dispose_llvm:
	.globl _p_42_plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle_Dispose_llvm
.private_extern _p_42_plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle_Dispose_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle_Dispose
plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle_Dispose:
_p_42:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #568]
br x16
.word 560
_p_43_plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_0_llvm:
	.globl _p_43_plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_0_llvm
.private_extern _p_43_plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_0_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_0
plt_System_Security_Cryptography__jit_icall_mono_create_corlib_exception_0:
_p_43:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #576]
br x16
.word 563
_p_44_plt_System_Security_Cryptography_System_Enum_GetName_System_Type_object_llvm:
	.globl _p_44_plt_System_Security_Cryptography_System_Enum_GetName_System_Type_object_llvm
.private_extern _p_44_plt_System_Security_Cryptography_System_Enum_GetName_System_Type_object_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Enum_GetName_System_Type_object
plt_System_Security_Cryptography_System_Enum_GetName_System_Type_object:
_p_44:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #584]
br x16
.word 566
_p_45_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte_llvm:
	.globl _p_45_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte_llvm
.private_extern _p_45_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_ReadOnlySpan_1_byte:
_p_45:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #592]
br x16
.word 569
_p_46_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte_llvm:
	.globl _p_46_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte_llvm
.private_extern _p_46_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_System_Span_1_byte:
_p_46:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #600]
br x16
.word 574
_p_47_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle_llvm:
	.globl _p_47_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle_llvm
.private_extern _p_47_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestReset_System_Security_Cryptography_Apple_SafeDigestCtxHandle:
_p_47:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #608]
br x16
.word 579
_p_48_plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle__ctor_intptr_bool_llvm:
	.globl _p_48_plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle__ctor_intptr_bool_llvm
.private_extern _p_48_plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle__ctor_intptr_bool_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle__ctor_intptr_bool
plt_System_Security_Cryptography_System_Runtime_InteropServices_SafeHandle__ctor_intptr_bool:
_p_48:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #616]
br x16
.word 584
_p_49_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFree_intptr_llvm:
	.globl _p_49_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFree_intptr_llvm
.private_extern _p_49_plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFree_intptr_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFree_intptr
plt_System_Security_Cryptography_Interop_AppleCrypto_DigestFree_intptr:
_p_49:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #624]
br x16
.word 587
_p_50_plt_System_Security_Cryptography__jit_icall_mini_init_method_rgctx_llvm:
	.globl _p_50_plt_System_Security_Cryptography__jit_icall_mini_init_method_rgctx_llvm
.private_extern _p_50_plt_System_Security_Cryptography__jit_icall_mini_init_method_rgctx_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mini_init_method_rgctx
plt_System_Security_Cryptography__jit_icall_mini_init_method_rgctx:
_p_50:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #632]
br x16
.word 592
_p_51_plt_System_Security_Cryptography__jit_icall_mono_thread_interruption_checkpoint_llvm:
	.globl _p_51_plt_System_Security_Cryptography__jit_icall_mono_thread_interruption_checkpoint_llvm
.private_extern _p_51_plt_System_Security_Cryptography__jit_icall_mono_thread_interruption_checkpoint_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_thread_interruption_checkpoint
plt_System_Security_Cryptography__jit_icall_mono_thread_interruption_checkpoint:
_p_51:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #640]
br x16
.word 595
_p_52_plt_System_Security_Cryptography__jit_icall_mono_arch_rethrow_exception_llvm:
	.globl _p_52_plt_System_Security_Cryptography__jit_icall_mono_arch_rethrow_exception_llvm
.private_extern _p_52_plt_System_Security_Cryptography__jit_icall_mono_arch_rethrow_exception_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_arch_rethrow_exception
plt_System_Security_Cryptography__jit_icall_mono_arch_rethrow_exception:
_p_52:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #648]
br x16
.word 598
_p_53_plt_System_Security_Cryptography__jit_icall_mono_thread_force_interruption_checkpoint_noraise_llvm:
	.globl _p_53_plt_System_Security_Cryptography__jit_icall_mono_thread_force_interruption_checkpoint_noraise_llvm
.private_extern _p_53_plt_System_Security_Cryptography__jit_icall_mono_thread_force_interruption_checkpoint_noraise_llvm
	.no_dead_strip plt_System_Security_Cryptography__jit_icall_mono_thread_force_interruption_checkpoint_noraise
plt_System_Security_Cryptography__jit_icall_mono_thread_force_interruption_checkpoint_noraise:
_p_53:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #656]
br x16
.word 600
_p_54_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor_llvm:
	.globl _p_54_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor_llvm
.private_extern _p_54_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor
plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle__ctor:
_p_54:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #664]
br x16
.word 603
_p_55_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int__llvm:
	.globl _p_55_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int__llvm
.private_extern _p_55_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int__llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_
plt_System_Security_Cryptography_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_:
_p_55:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #672]
br x16
.word 614
_p_56_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromUnmanaged_intptr_llvm:
	.globl _p_56_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromUnmanaged_intptr_llvm
.private_extern _p_56_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromUnmanaged_intptr_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromUnmanaged_intptr
plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_FromUnmanaged_intptr:
_p_56:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #680]
br x16
.word 619
_p_57_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free_llvm:
	.globl _p_57_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free_llvm
.private_extern _p_57_plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free_llvm
	.no_dead_strip plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free
plt_System_Security_Cryptography_System_Runtime_InteropServices_Marshalling_SafeHandleMarshaller_1_ManagedToUnmanagedOut_System_Security_Cryptography_Apple_SafeDigestCtxHandle_Free:
_p_57:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #688]
br x16
.word 630
_p_58_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int_llvm:
	.globl _p_58_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int_llvm
.private_extern _p_58_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int
plt_System_Security_Cryptography_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int:
_p_58:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #696]
br x16
.word 641
_p_59_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int_llvm:
	.globl _p_59_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int_llvm
.private_extern _p_59_plt_System_Security_Cryptography_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int_llvm
	.no_dead_strip plt_System_Security_Cryptography_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int
plt_System_Security_Cryptography_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int:
_p_59:
adrp x16, mono_aot_System_Security_Cryptography_got@PAGE+0
add x16, x16, mono_aot_System_Security_Cryptography_got@PAGEOFF
ldr x16, [x16, #704]
br x16
.word 646
plt_end:
_mono_aot_System_Security_Cryptographyplt_end:
	.globl _mono_aot_System_Security_Cryptographyplt_end
.section __DATA, __bss
	.align 3
jit_got:
_mono_aot_System_Security_Cryptographyjit_got:
	.globl _mono_aot_System_Security_Cryptographyjit_got
.lcomm mono_aot_System_Security_Cryptography_got, 712
got_end:
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 1, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.section __TEXT, __const
	.align 2
name_0:
	.asciz "_unbox_trampoline_p"
.data
	.align 3
globals:
_mono_aot_System_Security_Cryptographyglobals:
	.globl _mono_aot_System_Security_Cryptographyglobals
	.align 3
	.quad Lglobals_hash
	.align 3
	.quad name_0
	.align 3
	.quad _unbox_trampoline_p

	.long 0,0
.section __DWARF, __debug_info,regular,debug
LTDIE_0:

	.byte 8
	.asciz "_PAL_HashAlgorithm"

	.byte 4
LDIFF_SYM4=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM4
	.byte 9
	.asciz "Unknown"

	.byte 0,9
	.asciz "Md5"

	.byte 1,9
	.asciz "Sha1"

	.byte 2,9
	.asciz "Sha256"

	.byte 3,9
	.asciz "Sha384"

	.byte 4,9
	.asciz "Sha512"

	.byte 5,0,7
	.asciz "_PAL_HashAlgorithm"

LDIFF_SYM5=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM6=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM6
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM7=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM7
LTDIE_3:

	.byte 17
	.asciz "System_Object"

	.byte 16,7
	.asciz "System_Object"

LDIFF_SYM8=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM8
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM9=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM9
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM10=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM10
LTDIE_2:

	.byte 5
	.asciz "System_ValueType"

	.byte 16,16
LDIFF_SYM11=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM11
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM12=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM12
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM13=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM13
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM14=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM14
LTDIE_1:

	.byte 5
	.asciz "System_Int32"

	.byte 20,16
LDIFF_SYM15=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM16=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM16
	.byte 2,35,16,0,7
	.asciz "System_Int32"

LDIFF_SYM17=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM17
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM18=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM18
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM19=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM19
LTDIE_4:

	.byte 5
	.asciz "System_Boolean"

	.byte 17,16
LDIFF_SYM20=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM20
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM21=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM21
	.byte 2,35,16,0,7
	.asciz "System_Boolean"

LDIFF_SYM22=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM22
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM23=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM23
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM24=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM24
LTDIE_7:

	.byte 5
	.asciz "System_Runtime_ConstrainedExecution_CriticalFinalizerObject"

	.byte 16,16
LDIFF_SYM25=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM25
	.byte 2,35,0,0,7
	.asciz "System_Runtime_ConstrainedExecution_CriticalFinalizerObject"

LDIFF_SYM26=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM26
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM27=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM27
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM28=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM28
LTDIE_6:

	.byte 5
	.asciz "System_Runtime_InteropServices_SafeHandle"

	.byte 32,16
LDIFF_SYM29=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM29
	.byte 2,35,0,6
	.asciz "handle"

LDIFF_SYM30=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM30
	.byte 2,35,16,6
	.asciz "_state"

LDIFF_SYM31=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM31
	.byte 2,35,24,6
	.asciz "_ownsHandle"

LDIFF_SYM32=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM32
	.byte 2,35,28,6
	.asciz "_fullyInitialized"

LDIFF_SYM33=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM33
	.byte 2,35,29,0,7
	.asciz "System_Runtime_InteropServices_SafeHandle"

LDIFF_SYM34=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM34
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM35=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM35
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM36=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM36
LTDIE_5:

	.byte 5
	.asciz "System_Security_Cryptography_Apple_SafeDigestCtxHandle"

	.byte 32,16
LDIFF_SYM37=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM37
	.byte 2,35,0,0,7
	.asciz "System_Security_Cryptography_Apple_SafeDigestCtxHandle"

LDIFF_SYM38=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM38
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM39=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM39
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM40=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM40
	.byte 2
	.asciz "Interop/AppleCrypto:DigestCreate"
	.asciz "Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_"

	.byte 0,0
	.quad Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_
	.quad Lme_1

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM41=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM41
	.byte 2,141,24,3
	.asciz "param1"

LDIFF_SYM42=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM42
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM43=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM43
	.byte 2,141,48,11
	.asciz "V_1"

LDIFF_SYM44=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 1,106,11
	.asciz "V_2"

LDIFF_SYM45=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM45
	.byte 1,106,11
	.asciz "V_3"

LDIFF_SYM46=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM46
	.byte 2,141,32,11
	.asciz "V_4"

LDIFF_SYM47=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM47
	.byte 1,106,11
	.asciz "V_5"

LDIFF_SYM48=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM48
	.byte 2,141,56,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM49=Lfde0_end - Lfde0_start
	.long LDIFF_SYM49
Lfde0_start:

	.long 0
	.align 3
	.quad Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_

LDIFF_SYM50=Lme_1 - Interop_AppleCrypto_DigestCreate_Interop_AppleCrypto_PAL_HashAlgorithm_int_
	.long LDIFF_SYM50
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,154,12
	.align 3
Lfde0_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_8:

	.byte 5
	.asciz "System_Byte"

	.byte 17,16
LDIFF_SYM51=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM51
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM52=LDIE_U1 - Ldebug_info_start
	.long LDIFF_SYM52
	.byte 2,35,16,0,7
	.asciz "System_Byte"

LDIFF_SYM53=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM53
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM54=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM54
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM55=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 2
	.asciz "Interop/AppleCrypto:DigestUpdate"
	.asciz "Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int"

	.byte 0,0
	.quad Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
	.quad Lme_3

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM56=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM56
	.byte 2,141,40,3
	.asciz "param1"

LDIFF_SYM57=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM57
	.byte 2,141,48,3
	.asciz "param2"

LDIFF_SYM58=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM58
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM59=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM59
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM60=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM60
	.byte 1,106,11
	.asciz "V_2"

LDIFF_SYM61=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM61
	.byte 3,141,192,0,11
	.asciz "V_3"

LDIFF_SYM62=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM62
	.byte 1,105,11
	.asciz "V_4"

LDIFF_SYM63=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM63
	.byte 3,141,208,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM64=Lfde1_end - Lfde1_start
	.long LDIFF_SYM64
Lfde1_start:

	.long 0
	.align 3
	.quad Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int

LDIFF_SYM65=Lme_3 - Interop_AppleCrypto_DigestUpdate_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
	.long LDIFF_SYM65
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,152,16,153,15,68,154,14
	.align 3
Lfde1_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Interop/AppleCrypto:DigestFinal"
	.asciz "Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int"

	.byte 0,0
	.quad Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
	.quad Lme_5

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM66=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM66
	.byte 2,141,40,3
	.asciz "param1"

LDIFF_SYM67=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM67
	.byte 2,141,48,3
	.asciz "param2"

LDIFF_SYM68=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM68
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM69=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM69
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM70=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM70
	.byte 1,106,11
	.asciz "V_2"

LDIFF_SYM71=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM71
	.byte 3,141,192,0,11
	.asciz "V_3"

LDIFF_SYM72=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM72
	.byte 1,105,11
	.asciz "V_4"

LDIFF_SYM73=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM73
	.byte 3,141,208,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM74=Lfde2_end - Lfde2_start
	.long LDIFF_SYM74
Lfde2_start:

	.long 0
	.align 3
	.quad Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int

LDIFF_SYM75=Lme_5 - Interop_AppleCrypto_DigestFinal_System_Security_Cryptography_Apple_SafeDigestCtxHandle_byte__int
	.long LDIFF_SYM75
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,152,16,153,15,68,154,14
	.align 3
Lfde2_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_Interop/AppleCrypto:DigestFree"
	.asciz "wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr
	.quad Lme_40

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM76=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM76
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM77=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM77
	.byte 0,11
	.asciz "V_1"

LDIFF_SYM78=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM78
	.byte 0,11
	.asciz "V_2"

LDIFF_SYM79=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM79
	.byte 0,11
	.asciz "V_3"

LDIFF_SYM80=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM80
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM81=Lfde3_end - Lfde3_start
	.long LDIFF_SYM81
Lfde3_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr

LDIFF_SYM82=Lme_40 - wrapper_managed_to_native_Interop_AppleCrypto_DigestFree_intptr
	.long LDIFF_SYM82
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde3_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_Interop/AppleCrypto:<DigestCreate>g____PInvoke_1_0"
	.asciz "wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_"

	.byte 0,0
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_
	.quad Lme_41

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM83=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM83
	.byte 1,105,3
	.asciz "param1"

LDIFF_SYM84=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM84
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM85=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM85
	.byte 0,11
	.asciz "V_1"

LDIFF_SYM86=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM86
	.byte 0,11
	.asciz "V_2"

LDIFF_SYM87=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM87
	.byte 0,11
	.asciz "V_3"

LDIFF_SYM88=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM88
	.byte 1,106,11
	.asciz "V_4"

LDIFF_SYM89=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM89
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM90=Lfde4_end - Lfde4_start
	.long LDIFF_SYM90
Lfde4_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_

LDIFF_SYM91=Lme_41 - wrapper_managed_to_native_Interop_AppleCrypto__DigestCreateg____PInvoke_1_0_Interop_AppleCrypto_PAL_HashAlgorithm_int_
	.long LDIFF_SYM91
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde4_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_Interop/AppleCrypto:<DigestUpdate>g____PInvoke_3_0"
	.asciz "wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int"

	.byte 0,0
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int
	.quad Lme_42

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM92=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM92
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM93=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM93
	.byte 1,105,3
	.asciz "param2"

LDIFF_SYM94=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM94
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM95=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM95
	.byte 0,11
	.asciz "V_1"

LDIFF_SYM96=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM96
	.byte 0,11
	.asciz "V_2"

LDIFF_SYM97=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM97
	.byte 0,11
	.asciz "V_3"

LDIFF_SYM98=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM98
	.byte 1,106,11
	.asciz "V_4"

LDIFF_SYM99=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM99
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM100=Lfde5_end - Lfde5_start
	.long LDIFF_SYM100
Lfde5_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int

LDIFF_SYM101=Lme_42 - wrapper_managed_to_native_Interop_AppleCrypto__DigestUpdateg____PInvoke_3_0_intptr_byte__int
	.long LDIFF_SYM101
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,76,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8
	.byte 154,7,68,155,6,156,5
	.align 3
Lfde5_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_Interop/AppleCrypto:<DigestFinal>g____PInvoke_5_0"
	.asciz "wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int"

	.byte 0,0
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int
	.quad Lme_43

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM102=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM102
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM103=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM103
	.byte 1,105,3
	.asciz "param2"

LDIFF_SYM104=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM104
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM105=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM105
	.byte 0,11
	.asciz "V_1"

LDIFF_SYM106=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM106
	.byte 0,11
	.asciz "V_2"

LDIFF_SYM107=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM107
	.byte 0,11
	.asciz "V_3"

LDIFF_SYM108=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM108
	.byte 1,106,11
	.asciz "V_4"

LDIFF_SYM109=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM109
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM110=Lfde6_end - Lfde6_start
	.long LDIFF_SYM110
Lfde6_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int

LDIFF_SYM111=Lme_43 - wrapper_managed_to_native_Interop_AppleCrypto__DigestFinalg____PInvoke_5_0_intptr_byte__int
	.long LDIFF_SYM111
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,76,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8
	.byte 154,7,68,155,6,156,5
	.align 3
Lfde6_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_Interop/AppleCrypto:<DigestReset>g____PInvoke_9_0"
	.asciz "wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr
	.quad Lme_44

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM112=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM112
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM113=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM113
	.byte 0,11
	.asciz "V_1"

LDIFF_SYM114=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM114
	.byte 0,11
	.asciz "V_2"

LDIFF_SYM115=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM115
	.byte 0,11
	.asciz "V_3"

LDIFF_SYM116=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM116
	.byte 1,106,11
	.asciz "V_4"

LDIFF_SYM117=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM117
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM118=Lfde7_end - Lfde7_start
	.long LDIFF_SYM118
Lfde7_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr

LDIFF_SYM119=Lme_44 - wrapper_managed_to_native_Interop_AppleCrypto__DigestResetg____PInvoke_9_0_intptr
	.long LDIFF_SYM119
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde7_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.text
	.align 3
mem_end:
