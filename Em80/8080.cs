using System.Collections;

namespace Em80
{
    public static class emulatedSystem
    {
        public static class io
        {
            public static frmConsole formConsole = new frmConsole();

            public static class Keyboard
            {
                private static byte[] buff = new byte[32];
                private static int head;
                private static int tail;
                public static bool byte_aval
                {
                    get { return head != tail; }
                }
                public static void KeyPress(byte val)
                {
                    int next = (head + 1) % 32;
                    if (next != tail)
                    {
                        buff[head] = val;
                        head = next;
                    }
                }

                public static byte GetKey()
                {
                    if (!byte_aval) return 0;

                    byte val = buff[tail];
                    tail = (tail + 1) % 32;
                    return val;
                }
            }



            public static void o(byte port)
            {
                if (port == 2 || port == 17)  // console data
                {
                    formConsole.WriteToConsole(cpu.registers.a);
                }
            }

            public static void i(byte port)
            {
                switch (port)
                {
                    case 2:  // console data (imsai sio)
                    case 17: // console data (altair sio)
                        cpu.registers.a = Keyboard.GetKey();
                        break;
                    case 3: // console status (imsai sio)
                        cpu.registers.a = 0x01; // tx always ready
                        if (Keyboard.byte_aval) cpu.registers.a |= 0x02;    // rx ready if a char is waiting
                        break;
                    case 16: // console status (altair sio)
                        cpu.registers.a = 0x02; // tx always ready
                        if (Keyboard.byte_aval) cpu.registers.a |= 0x01;    // rx ready if a char is waiting
                        break;
                    default:    // something else
                        cpu.registers.a = 0;
                        break;
                }
            }
        }
        public static class memory
        {
            public static byte[] bytes;

            public static void init()
            {
                bytes = new byte[65536];
            }

            public static ushort get_16()
            {
                ushort val;
                val = memory.bytes[cpu.registers.pc++];
                val |= (ushort)(memory.bytes[cpu.registers.pc++] << 8);
                return val;
            }

            public static ushort pop()
            {
                ushort val;
                val = memory.bytes[cpu.registers.sp++];
                val |= (ushort)(memory.bytes[cpu.registers.sp++] << 8);
                return val;
            }

            public static void push(ushort val)
            {
                memory.bytes[--cpu.registers.sp] = (byte)(val >> 8);
                memory.bytes[--cpu.registers.sp] = (byte)val;
            }
        }

        public static class cpu
        {
            public static bool running = false;

            public static class registers
            {
                public static ushort pc, sp;
                public static byte a, f, b, c, d, e, h, l;
                public static ushort af
                {
                    get { return (ushort)(((ushort)a << 8) | f); }
                    set { a = (byte)(value >> 8); f = (byte)value; }
                }

                public static ushort bc
                {
                    get { return (ushort)(((ushort)b << 8) | c); }
                    set { b = (byte)(value >> 8); c = (byte)value; }
                }

                public static ushort de
                {
                    get { return (ushort)(((ushort)d << 8) | e); }
                    set { d = (byte)(value >> 8); e = (byte)value; }
                }

                public static ushort hl
                {
                    get { return (ushort)(((ushort)h << 8) | l); }
                    set { h = (byte)(value >> 8); l = (byte)value; }
                }

                public static byte m
                {
                    get { return memory.bytes[hl]; }
                    set { memory.bytes[hl] = value; }
                }
            }

            public static class flags
            {
                public static bool[] parityBits = new bool[256]
                {
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false,
                    true, false, false, true, false, true, true, false, false, true, true, false, true, false, false, true
                };

                public static bool s
                {
                    get { return (registers.f & 0x80) != 0; }
                    set { if (value) registers.f |= 0x80; else registers.f &= 0x7f; }
                }

                public static bool z
                {
                    get { return (registers.f & 0x40) != 0; }
                    set { if (value) registers.f |= 0x40; else registers.f &= 0xbf; }
                }

                public static bool i
                {
                    get { return (registers.f & 0x20) != 0; }
                    set { if (value) registers.f |= 0x20; else registers.f &= 0xdf; }
                }

                public static bool a
                {
                    get { return (registers.f & 0x10) != 0; }
                    set { if (value) registers.f |= 0x10; else registers.f &= 0xef; }
                }

                public static bool p
                {
                    get { return (registers.f & 0x04) != 0; }
                    set { if (value) registers.f |= 0x04; else registers.f &= 0xfb; }
                }

                public static bool c
                {
                    get { return (registers.f & 0x01) != 0; }
                    set { if (value) registers.f |= 0x01; else registers.f &= 0xfe; }
                }
            }

            public static class functions
            {
                public static byte add_8(byte x, byte y, bool carry = false)
                {
                    /* Add two 8 bit values and update flags. Optional update of carry flag */
                    ushort w = (ushort)(x + y);
                    flags.s = (w & 0x80) == 0x80;
                    flags.z = ((byte)w == 0);
                    flags.a = (((x & 0x0f) + (y & 0x0f)) & 0x10) > 0;
                    flags.p = flags.parityBits[(byte)w];
                    if (carry) flags.c = (w & 0xff00) > 0;
                    return (byte)w;
                }

                public static byte sub_8(byte x, byte y, bool carry = false)
                {
                    /* Subtract two 8 bit values and update flags. Optional update of carry flag */
                    short w = (short)(x - y);
                    flags.s = (w & 0x80) == 0x80;
                    flags.z = ((byte)w == 0);
                    flags.a = (((x & 0x0f) - (y & 0x0f)) & 0x10) > 0;
                    flags.p = flags.parityBits[(byte)w];
                    if (carry) flags.c = (w & 0xff00) > 0;
                    return (byte)w;
                }

                public static ushort add_16(ushort x, ushort y)
                {
                    /* Add two 16 bit values and update carry flag */
                    uint w = (uint)(x + y);
                    flags.c = (w & 0xff0000) > 0;
                    return (ushort)w;
                }

                public static ushort sub_16(ushort x, ushort y)
                {
                    /* Subtract two 16 bit values and update carry flag */
                    uint w = (uint)(x - y);
                    flags.c = (w & 0xff0000) > 0;
                    return (ushort)w;
                }

                public static void ana(byte x)
                {
                    registers.a &= x;
                    flags.s = (registers.a & 0x80) == 0x80;
                    flags.z = (registers.a == 0);
                    flags.p = flags.parityBits[registers.a];
                    flags.c = false;
                }

                public static void xra(byte x)
                {
                    registers.a ^= x;
                    flags.s = (registers.a & 0x80) == 0x80;
                    flags.z = (registers.a == 0);
                    flags.p = flags.parityBits[registers.a];
                    flags.c = false;
                }

                public static void ora(byte x)
                {
                    registers.a |= x;
                    flags.s = (registers.a & 0x80) == 0x80;
                    flags.z = (registers.a == 0);
                    flags.p = flags.parityBits[registers.a];
                    flags.c = false;
                }
            }

            public static void reset()
            {
                registers.pc = 0;
                registers.sp = 0;
                registers.a = 0;
                registers.b = 0;
                registers.c = 0;
                registers.d = 0;
                registers.e = 0;
                registers.f = 0x02;
                registers.h = 0;
                registers.l = 0;
            }

            public static void cycle()
            {
                bool boolTemp;
                ushort ushortTemp;

                switch(memory.bytes[registers.pc++])
                {
                    case 0x01:  /* LXI B,d16 */
                        registers.c = memory.bytes[registers.pc++];
                        registers.b = memory.bytes[registers.pc++];
                        break;
                    case 0x02:  /* STAX B */
                        memory.bytes[registers.bc] = registers.a;
                        break;
                    case 0x03:  /* INX B */
                        registers.bc++;
                        break;
                    case 0x04:  /* INR B */
                        registers.b = functions.add_8(registers.b, 1);
                        break;
                    case 0x05:  /* DCR B */
                        registers.b = functions.sub_8(registers.b, 1);
                        break;
                    case 0x06:  /* MVI B,d8 */
                        registers.b = memory.bytes[registers.pc++];
                        break;
                    case 0x07:  /* RLC */
                        flags.c = (registers.a & 0x80) == 0x80;
                        registers.a <<= 1;
                        if (flags.c) registers.a |= 0x01;
                        break;
                    // 0x08: NOP
                    case 0x09:  /* DAD B */
                        registers.hl = functions.add_16(registers.hl, registers.bc);
                        break;
                    case 0x0a:  /* LDAX B */
                        registers.a = memory.bytes[registers.bc];
                        break;
                    case 0x0b:  /* DCX B */
                        registers.bc--;
                        break;
                    case 0x0c:  /* INR C */
                        registers.c = functions.add_8(registers.c, 1);
                        break;
                    case 0x0d:  /* DCR C */
                        registers.c = functions.sub_8(registers.c, 1);
                        break;
                    case 0x0e:  /* MVI C,d8 */
                        registers.c = memory.bytes[registers.pc++];
                        break;
                    case 0x0f:  /* RRC */
                        flags.c = (registers.a & 0x01) == 0x01;
                        registers.a >>= 1;
                        if (flags.c) registers.a |= 0x80;
                        break;
                    // 0x11: NOP
                    case 0x11:  /* LXI D,d16 */
                        registers.e = memory.bytes[registers.pc++];
                        registers.d = memory.bytes[registers.pc++];
                        break;
                    case 0x12:  /* STAX D */
                        memory.bytes[registers.de] = registers.a;
                        break;
                    case 0x13:  /* INX D */
                        registers.de++;
                        break;
                    case 0x14:  /* INR D */
                        registers.d = functions.add_8(registers.d, 1);
                        break;
                    case 0x15:  /* DCR D */
                        registers.d = functions.sub_8(registers.d, 1);
                        break;
                    case 0x16:  /* MVI D,d8 */
                        registers.d = memory.bytes[registers.pc++];
                        break;
                    case 0x17:  /* RAL */
                        boolTemp = flags.c;
                        flags.c = (registers.a & 0x80) == 0x80;
                        registers.a <<= 1;
                        if (boolTemp) registers.a |= 0x01;
                        break;
                    // 0x18: NOP
                    case 0x19:  /* DAD D */
                        registers.hl = functions.add_16(registers.hl, registers.de);
                        break;
                    case 0x1a:  /* LDAX D */
                        registers.a = memory.bytes[registers.de];
                        break;
                    case 0x1b:  /* DCX D */
                        registers.de--;
                        break;
                    case 0x1c:  /* INR E */
                        registers.e = functions.add_8(registers.e, 1);
                        break;
                    case 0x1d:  /* DCR E */
                        registers.e = functions.sub_8(registers.e, 1);
                        break;
                    case 0x1e:  /* MVI E,d8 */
                        registers.e = memory.bytes[registers.pc++];
                        break;
                    case 0x1f:  /* RAR */
                        boolTemp = flags.c;
                        flags.c = (registers.a & 0x01) == 0x01;
                        registers.a >>= 1;
                        if (boolTemp) registers.a |= 0x80;
                        break;
                    // 0x20: NOP
                    case 0x21:  /* LXI H,d16 */
                        registers.l = memory.bytes[registers.pc++];
                        registers.h = memory.bytes[registers.pc++];
                        break;
                    case 0x22:  /* SHLD a16 */
                        ushortTemp = memory.get_16();
                        memory.bytes[ushortTemp++] = registers.l;
                        memory.bytes[ushortTemp] = registers.h;
                        break;
                    case 0x23:  /* INX H */
                        registers.hl++;
                        break;
                    case 0x24:  /* INR H */
                        registers.h = functions.add_8(registers.h, 1);
                        break;
                    case 0x25:  /* DCR H */
                        registers.h = functions.sub_8(registers.h, 1);
                        break;
                    case 0x26:  /* MVI H,d8 */
                        registers.h = memory.bytes[registers.pc++];
                        break;
                    case 0x27:  /* DAA */
                        boolTemp = flags.c;
                        if (flags.a || (registers.a & 0x0f) > 9) registers.a = functions.add_8(registers.a, 6);
                        flags.c = boolTemp;
                        boolTemp = flags.a;
                        if (flags.c || ((registers.a & 0xf0) >> 4) > 9) registers.a = functions.add_8(registers.a, 0x60, true);
                        flags.a = boolTemp;
                        break;
                    // 0x28: NOP
                    case 0x29:  /* DAD H */
                        registers.hl = functions.add_16(registers.hl, registers.hl);
                        break;
                    case 0x2a:  /* LHLD a16 */
                        ushortTemp = memory.get_16();
                        registers.l = memory.bytes[ushortTemp++];
                        registers.h = memory.bytes[ushortTemp];
                        break;
                    case 0x2b:  /* DCX H */
                        registers.hl--;
                        break;
                    case 0x2c:  /* INR L */
                        registers.l = functions.add_8(registers.l, 1);
                        break;
                    case 0x2d:  /* DCR L */
                        registers.l = functions.sub_8(registers.l, 1);
                        break;
                    case 0x2e:  /* MVI L,d8 */
                        registers.l = memory.bytes[registers.pc++];
                        break;
                    case 0x2f:  /* CMA */
                        registers.a = (byte)~registers.a;
                        break;
                    // 0x30: NOP
                    case 0x31:  /* LXI SP,d16 */
                        registers.sp = memory.get_16();
                        break;
                    case 0x32:  /* STA a16 */
                        memory.bytes[memory.get_16()] = registers.a;
                        break;
                    case 0x33:  /* INX SP */
                        registers.sp++;
                        break;
                    case 0x34:  /* INR M */
                        registers.m = functions.add_8(registers.m, 1);
                        break;
                    case 0x35:  /* DCR M */
                        registers.m = functions.sub_8(registers.m, 1);
                        break;
                    case 0x36:  /* MVI M,d8 */
                        registers.m = memory.bytes[registers.pc++];
                        break;
                    case 0x37:  /* STC */
                        flags.c = true;
                        break;
                    // 0x38: NOP
                    case 0x39:  /* DAD SP */
                        registers.hl = functions.add_16(registers.hl, registers.sp);
                        break;
                    case 0x3a:  /* LDA a16 */
                        registers.a = memory.bytes[memory.get_16()];
                        break;
                    case 0x3b:  /* DCX SP */
                        registers.sp--;
                        break;
                    case 0x3c:  /* INR A */
                        registers.a = functions.add_8(registers.a, 1);
                        break;
                    case 0x3d:  /* DCR A */
                        registers.a = functions.sub_8(registers.a, 1);
                        break;
                    case 0x3e:  /* MVI A,d8 */
                        registers.a = memory.bytes[registers.pc++];
                        break;
                    case 0x3f:  /* CMC */
                        flags.c = !flags.c;
                        break;
                    // 0x40: MOV B,B
                    case 0x41:  /* MOV B,C */
                        registers.b = registers.c;
                        break;
                    case 0x42:  /* MOV B,D */
                        registers.b = registers.d;
                        break;
                    case 0x43:  /* MOV B,E */
                        registers.b = registers.e;
                        break;
                    case 0x44:  /* MOV B,H */
                        registers.b = registers.h;
                        break;
                    case 0x45:  /* MOV B,L */
                        registers.b = registers.l;
                        break;
                    case 0x46:  /* MOV B,M */
                        registers.b = registers.m;
                        break;
                    case 0x47:  /* MOV B,A */
                        registers.b = registers.a;
                        break;
                    case 0x48:  /* MOV C,B */
                        registers.c = registers.b;
                        break;
                    // 0x49: MOV C,C
                    case 0x4a:  /* MOV C,D */
                        registers.c = registers.d;
                        break;
                    case 0x4b:  /* MOV C,E */
                        registers.c = registers.e;
                        break;
                    case 0x4c:  /* MOV C,H */
                        registers.c = registers.h;
                        break;
                    case 0x4d:  /* MOV C,L */
                        registers.c = registers.l;
                        break;
                    case 0x4e:  /* MOV C,M */
                        registers.c = registers.m;
                        break;
                    case 0x4f:  /* MOV C,A */
                        registers.c = registers.a;
                        break;
                    case 0x50:  /* MOV D,B */
                        registers.d = registers.b;
                        break;
                    case 0x51:  /* MOV D,C */
                        registers.d = registers.c;
                        break;
                    // 0x52: MOV D,D
                    case 0x53:  /* MOV D,E */
                        registers.d = registers.e;
                        break;
                    case 0x54:  /* MOV D,H */
                        registers.d = registers.h;
                        break;
                    case 0x55:  /* MOV D,L */
                        registers.d = registers.l;
                        break;
                    case 0x56:  /* MOV D,M */
                        registers.d = registers.m;
                        break;
                    case 0x57:  /* MOV D,A */
                        registers.d = registers.a;
                        break;
                    case 0x58:  /* MOV E,B */
                        registers.e = registers.b;
                        break;
                    case 0x59:  /* MOV E,C */
                        registers.e = registers.c;
                        break;
                    case 0x5a:  /* MOV E,D */
                        registers.e = registers.d;
                        break;
                    // 0x5b: MOV E,E
                    case 0x5c:  /* MOV E,H */
                        registers.e = registers.h;
                        break;
                    case 0x5d:  /* MOV E,L */
                        registers.e = registers.l ;
                        break;
                    case 0x5e:  /* MOV E,M */
                        registers.e = registers.m;
                        break;
                    case 0x5f:  /* MOV E,A */
                        registers.e = registers.a;
                        break;
                    case 0x60:  /* MOV H,B */
                        registers.h = registers.b;
                        break;
                    case 0x61:  /* MOV H,C */
                        registers.h = registers.c;
                        break;
                    case 0x62:  /* MOV H,D */
                        registers.h = registers.d;
                        break;
                    case 0x63:  /* MOV H,E */
                        registers.h = registers.e;
                        break;
                    // 0x64: MOV H,H
                    case 0x65:  /* MOV H,L */
                        registers.h = registers.l;
                        break;
                    case 0x66:  /* MOV H,M */
                        registers.h = registers.m;
                        break;
                    case 0x67:  /* MOV H,A */
                        registers.h = registers.a;
                        break;
                    case 0x68:  /* MOV L,B */
                        registers.l = registers.b;
                        break;
                    case 0x69:  /* MOV L,C */
                        registers.l = registers.c;
                        break;
                    case 0x6a:  /* MOV L,D */
                        registers.l = registers.d;
                        break;
                    case 0x6b:  /* MOV L,E */
                        registers.l = registers.e;
                        break;
                    case 0x6c:  /* MOV L,H */
                        registers.l = registers.h;
                        break;
                    // 0c6d: MOV L,L
                    case 0x6e:  /* MOV L,M */
                        registers.l = registers.m;
                        break;
                    case 0x6f:  /* MOV L,A */
                        registers.l = registers.a;
                        break;
                    case 0x70:  /* MOV M,B */
                        registers.m = registers.b;
                        break;
                    case 0x71:  /* MOV M,C */
                        registers.m = registers.c;
                        break;
                    case 0x72:  /* MOV M,D */
                        registers.m = registers.d;
                        break;
                    case 0x73:  /* MOV M,E */
                        registers.m = registers.e;
                        break;
                    case 0x74:  /* MOV M,H */
                        registers.m = registers.h;
                        break;
                    case 0x75:  /* MOV M,L */
                        registers.m = registers.l;
                        break;
                    case 0x76:  /* HLT */
                        running = false;
                        break;
                    case 0x77:  /* MOV M,A */
                        registers.m = registers.a;
                        break;
                    case 0x78:  /* MOV A,B */
                        registers.a = registers.b;
                        break;
                    case 0x79:  /* MOV A,C */
                        registers.a = registers.c;
                        break;
                    case 0x7a:  /* MOV A,D */
                        registers.a = registers.d;
                        break;
                    case 0x7b:  /* MOV A,E */
                        registers.a = registers.e;
                        break;
                    case 0x7c:  /* MOV A,H */
                        registers.a = registers.h;
                        break;
                    case 0x7d:  /* MOV A,L */
                        registers.a = registers.l;
                        break;
                    case 0x7e:  /* MOV A,M */
                        registers.a = registers.m;
                        break;
                    // 0x7f: MOV A,A
                    case 0x80:  /* ADD B */
                        registers.a = functions.add_8(registers.a, registers.b, true);
                        break;
                    case 0x81:  /* ADD C */
                        registers.a = functions.add_8(registers.a, registers.c, true);
                        break;
                    case 0x82:  /* ADD D */
                        registers.a = functions.add_8(registers.a, registers.d, true);
                        break;
                    case 0x83:  /* ADD E */
                        registers.a = functions.add_8(registers.a, registers.e, true);
                        break;
                    case 0x84:  /* ADD H */
                        registers.a = functions.add_8(registers.a, registers.h, true);
                        break;
                    case 0x85:  /* ADD L */
                        registers.a = functions.add_8(registers.a, registers.l, true);
                        break;
                    case 0x86:  /* ADD M */
                        registers.a = functions.add_8(registers.a, registers.m, true);
                        break;
                    case 0x87:  /* ADD B */
                        registers.a = functions.add_8(registers.a, registers.a, true);
                        break;
                    case 0x88:  /* ADC B */
                        registers.a = functions.add_8(registers.a, (byte)(registers.b + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x89:  /* ADC C */
                        registers.a = functions.add_8(registers.a, (byte)(registers.c + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x8a:  /* ADC D */
                        registers.a = functions.add_8(registers.a, (byte)(registers.d + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x8b:  /* ADC E */
                        registers.a = functions.add_8(registers.a, (byte)(registers.e + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x8c:  /* ADC H */
                        registers.a = functions.add_8(registers.a, (byte)(registers.h + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x8d:  /* ADC L */
                        registers.a = functions.add_8(registers.a, (byte)(registers.l + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x8e:  /* ADC M */
                        registers.a = functions.add_8(registers.a, (byte)(registers.m + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x8f:  /* ADC A */
                        registers.a = functions.add_8(registers.a, (byte)(registers.a + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x90:  /* SUB B */
                        registers.a = functions.sub_8(registers.a, registers.b, true);
                        break;
                    case 0x91:  /* SUB C */
                        registers.a = functions.sub_8(registers.a, registers.c, true);
                        break;
                    case 0x92:  /* SUB D */
                        registers.a = functions.sub_8(registers.a, registers.d, true);
                        break;
                    case 0x93:  /* SUB E */
                        registers.a = functions.sub_8(registers.a, registers.e, true);
                        break;
                    case 0x94:  /* SUB H */
                        registers.a = functions.sub_8(registers.a, registers.h, true);
                        break;
                    case 0x95:  /* SUB L */
                        registers.a = functions.sub_8(registers.a, registers.l, true);
                        break;
                    case 0x96:  /* SUB M */
                        registers.a = functions.sub_8(registers.a, registers.m, true);
                        break;
                    case 0x97:  /* SUB A */
                        registers.a = functions.sub_8(registers.a, registers.a, true);
                        break;
                    case 0x98:  /* SBB B */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.b + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x99:  /* SBB C */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.c + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x9a:  /* SBB D */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.d + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x9b:  /* SBB E */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.e + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x9c:  /* SBB H */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.h + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x9d:  /* SBB L */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.l + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x9e:  /* SBB M */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.m + (flags.c ? 1 : 0)), true);
                        break;
                    case 0x9f:  /* SBB A */
                        registers.a = functions.sub_8(registers.a, (byte)(registers.a + (flags.c ? 1 : 0)), true);
                        break;
                    case 0xa0:  /* ANA B */
                        functions.ana(registers.b);
                        break;
                    case 0xa1:  /* ANA C */
                        functions.ana(registers.c);
                        break;
                    case 0xa2:  /* ANA D */
                        functions.ana(registers.d);
                        break;
                    case 0xa3:  /* ANA E */
                        functions.ana(registers.e);
                        break;
                    case 0xa4:  /* ANA H */
                        functions.ana(registers.h);
                        break;
                    case 0xa5:  /* ANA L */
                        functions.ana(registers.l);
                        break;
                    case 0xa6:  /* ANA M */
                        functions.ana(registers.m);
                        break;
                    case 0xa7:  /* ANA A */
                        functions.ana(registers.a);
                        break;
                    case 0xa8:  /* XRA B */
                        functions.xra(registers.b);
                        break;
                    case 0xa9:  /* XRA C */
                        functions.xra(registers.c);
                        break;
                    case 0xaa:  /* XRA D */
                        functions.xra(registers.d);
                        break;
                    case 0xab:  /* XRA E */
                        functions.xra(registers.e);
                        break;
                    case 0xac:  /* XRA H */
                        functions.xra(registers.h);
                        break;
                    case 0xad:  /* XRA L */
                        functions.xra(registers.l);
                        break;
                    case 0xae:  /* XRA M */
                        functions.xra(registers.m);
                        break;
                    case 0xaf:  /* XRA A */
                        functions.xra(registers.a);
                        break;
                    case 0xb0:  /* ORA B */
                        functions.ora(registers.b);
                        break;
                    case 0xb1:  /* ORA C */
                        functions.ora(registers.c);
                        break;
                    case 0xb2:  /* ORA D */
                        functions.ora(registers.d);
                        break;
                    case 0xb3:  /* ORA E */
                        functions.ora(registers.e);
                        break;
                    case 0xb4:  /* ORA H */
                        functions.ora(registers.h);
                        break;
                    case 0xb5:  /* ORA L */
                        functions.ora(registers.l);
                        break;
                    case 0xb6:  /* ORA M */
                        functions.ora(registers.m);
                        break;
                    case 0xb7:  /* ORA A */
                        functions.ora(registers.a);
                        break;
                    case 0xb8:  /* CMP B */
                        functions.sub_8(registers.a, registers.b, true);
                        break;
                    case 0xb9:  /* CMP C */
                        functions.sub_8(registers.a, registers.c, true);
                        break;
                    case 0xba:  /* CMP D */
                        functions.sub_8(registers.a, registers.d, true);
                        break;
                    case 0xbb:  /* CMP E */
                        functions.sub_8(registers.a, registers.e, true);
                        break;
                    case 0xbc:  /* CMP H */
                        functions.sub_8(registers.a, registers.h, true);
                        break;
                    case 0xbd:  /* CMP L */
                        functions.sub_8(registers.a, registers.l, true);
                        break;
                    case 0xbe:  /* CMP M */
                        functions.sub_8(registers.a, registers.m, true);
                        break;
                    case 0xbf:  /* CMP A */
                        functions.sub_8(registers.a, registers.a, true);
                        break;
                    case 0xc0:  /* RNZ */
                        if (!flags.z) registers.pc = memory.pop();
                        break;
                    case 0xc1:  /* POP B */
                        registers.bc = memory.pop();
                        break;
                    case 0xc2:  /* JNZ a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.z) registers.pc = ushortTemp;
                        break;
                    case 0xc3:  /* JMP a16 */
                    case 0xcb:
                        registers.pc = memory.get_16();
                        break;
                    case 0xc4:  /* CNZ a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.z)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xc5:  /* PUSH B */
                        memory.push(registers.bc);
                        break;
                    case 0xc6:  /* ADI d8 */
                        registers.a = functions.add_8(registers.a, memory.bytes[registers.pc++], true);
                        break;
                    case 0xc7:  /* RST 0 */
                        memory.push(registers.pc);
                        registers.pc = 0;
                        break;
                    case 0xc8:  /* RZ */
                        if (flags.z) registers.pc = memory.pop();
                        break;
                    case 0xc9:  /* RET */
                    case 0xd9:
                        registers.pc = memory.pop();
                        break;
                    case 0xca:  /* JZ a16 */
                        ushortTemp = memory.get_16();
                        if (flags.z) registers.pc = ushortTemp;
                        break;
                    case 0xcc:  /* CZ a16 */
                        ushortTemp = memory.get_16();
                        if (flags.z)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xcd:  /* CALL a16 */
                    case 0xdd:
                    case 0xed:
                    case 0xfd:
                        memory.push((ushort)(registers.pc + 2));
                        registers.pc = memory.get_16();
                        break;
                    case 0xce:  /* ACI d8 */
                        registers.a = functions.add_8(registers.a, (byte)(memory.bytes[registers.pc++] + (flags.c ? 1 : 0)), true);
                        break;
                    case 0xcf:  /* RST 1 */
                        memory.push(registers.pc);
                        registers.pc = 0x8;
                        break;
                    case 0xd0:  /* RNC */
                        if (!flags.c) registers.pc = memory.pop();
                        break;
                    case 0xd1:  /* POP D */
                        registers.de = memory.pop();
                        break;
                    case 0xd2:  /* JNC a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.c) registers.pc = ushortTemp;
                        break;
                    case 0xd3:  /* OUT d8 */
                        io.o(memory.bytes[registers.pc++]);
                        break;
                    case 0xd4:  /* CNC a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.c)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xd5:  /* PUSH D */
                        memory.push(registers.de);
                        break;
                    case 0xd6:  /* SUI d8 */
                        registers.a = functions.sub_8(registers.a, memory.bytes[registers.pc++], true);
                        break;
                    case 0xd7:  /* RST 2 */
                        memory.push(registers.pc);
                        registers.pc = 0x10;
                        break;
                    case 0xd8:  /* RC */
                        if (flags.c) registers.pc = memory.pop();
                        break;
                    case 0xda:  /* JC a16 */
                        ushortTemp = memory.get_16();
                        if (flags.c) registers.pc = ushortTemp;
                        break;
                    case 0xdb:  /* IN d8 */
                        io.i(memory.bytes[registers.pc++]);
                        break;
                    case 0xdc:  /* CC a16 */
                        ushortTemp = memory.get_16();
                        if (flags.c)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xde:  /* SBI d8 */
                        registers.a = functions.sub_8(registers.a, (byte)(memory.bytes[registers.pc++] + (flags.c ? 1 : 0)), true);
                        break;
                    case 0xdf:  /* RST 3 */
                        memory.push(registers.pc);
                        registers.pc = 0x18;
                        break;
                    case 0xe0:  /* RPO */
                        if (!flags.p) registers.pc = memory.pop();
                        break;
                    case 0xe1:  /* POP H */
                        registers.hl = memory.pop();
                        break;
                    case 0xe2:  /* JPO a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.p) registers.pc = ushortTemp;
                        break;
                    case 0xe3:  /* XTHL */
                        ushortTemp = memory.pop();
                        memory.push(registers.hl);
                        registers.hl = ushortTemp;
                        break;
                    case 0xe4:  /* CPO a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.p)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xe5:  /* PUSH H */
                        memory.push(registers.hl);
                        break;
                    case 0xe6:  /* ANI d8 */
                        functions.ana(memory.bytes[registers.pc++]);
                        break;
                    case 0xe7:  /* RST 4 */
                        memory.push(registers.pc);
                        registers.pc = 0x20;
                        break;
                    case 0xe8:  /* RPE */
                        if (flags.p) registers.pc = memory.pop();
                        break;
                    case 0xe9:  /* PCHL */
                        registers.pc = registers.hl;
                        break;
                    case 0xea:  /* JPE a16 */
                        ushortTemp = memory.get_16();
                        if (flags.p) registers.pc = ushortTemp;
                        break;
                    case 0xeb:  /* XCHG */
                        ushortTemp = registers.de;
                        registers.de = registers.hl;
                        registers.hl = ushortTemp;
                        break;
                    case 0xec:  /* CPE a16 */
                        ushortTemp = memory.get_16();
                        if (flags.p)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xee:  /* XRI d8 */
                        functions.xra(memory.bytes[registers.pc++]);
                        break;
                    case 0xef:  /* RST 5 */
                        memory.push(registers.pc);
                        registers.pc = 0x28;
                        break;
                    case 0xf0:  /* RP */
                        if (!flags.s) registers.pc = memory.pop();
                        break;
                    case 0xf1:  /* POP PSW */
                        registers.af = memory.pop();
                        break;
                    case 0xf2:  /* JP a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.s) registers.pc = ushortTemp;
                        break;
                    case 0xf3:  /* DI */
                        flags.i = false;
                        break;
                    case 0xf4:  /* CP a16 */
                        ushortTemp = memory.get_16();
                        if (!flags.s)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xf5:  /* PUSH PSW */
                        memory.push(registers.af);
                        break;
                    case 0xf6:  /* ORI d8 */
                        functions.ora(memory.bytes[registers.pc++]);
                        break;
                    case 0xf7:  /* RST 6 */
                        memory.push(registers.pc);
                        registers.pc = 0x30;
                        break;
                    case 0xf8:  /* RM */
                        if (flags.s) registers.pc = memory.pop();
                        break;
                    case 0xf9:  /* SPHL */
                        registers.sp = registers.hl;
                        break;
                    case 0xfa:  /* JM a16 */
                        ushortTemp = memory.get_16();
                        if (flags.s) registers.pc = ushortTemp;
                        break;
                    case 0xfb:  /* EI */
                        flags.i = true;
                        break;
                    case 0xfc:  /* CM a16 */
                        ushortTemp = memory.get_16();
                        if (flags.s)
                        {
                            memory.push(registers.pc);
                            registers.pc = ushortTemp;
                        }
                        break;
                    case 0xfe:  /* CPI d8 */
                        functions.sub_8(registers.a, memory.bytes[registers.pc++], true);
                        break;
                    case 0xff:  /* RST 7 */
                        memory.push(registers.pc);
                        registers.pc = 0x38;
                        break;
                    default:
                        break;
                }
            }
        }
    }

}