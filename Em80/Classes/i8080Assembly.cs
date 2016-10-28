using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    static class i8080Assembly
    {
        public static string[] mnemonics = new string[]
        {
            "NOP",      "LXI B,",   "STAX B",   "INX B",    "INR B",    "DCR B",    "MVI B,",   "RLC",
            "NOP",      "DAD B",    "LDAX B",   "DCX B",    "INR C",    "DCR C",    "MVI C,",   "RRC",
            "NOP",      "LXI D,",   "STAX D",   "INX D",    "INR D",    "DCR D",    "MVI D,",   "RAL",
            "NOP",      "DAD D",    "LDAX D",   "DCX D",    "INR E",    "DCR E",    "MVI E,",   "RAR",
            "NOP",      "LXI H,",   "SHLD ",    "INX H",    "INR H",    "DCR H",    "MVI H,",   "DAA",
            "NOP",      "DAD H",    "LHLD ",    "DCX H",    "INR L",    "DCR L",    "MVI L,",   "CMA",
            "NOP",      "LXI SP,",  "STA ",     "INX SP",   "INR M",    "DCR M",    "MVI M,",   "STC",
            "NOP",      "DAD SP",   "LDA ",     "DCX SP",   "INR A",    "DCR A",    "MVI A,",   "CMC",
            "MOV B,B",  "MOV B,C",  "MOV B,D",  "MOV B,E",  "MOV B,H",  "MOV B,L",  "MOV B,M",  "MOV B,A",
            "MOV C,B",  "MOV C,C",  "MOV C,D",  "MOV C,E",  "MOV C,H",  "MOV C,L",  "MOV C,M",  "MOV C,A",
            "MOV D,B",  "MOV D,C",  "MOV D,D",  "MOV D,E",  "MOV D,H",  "MOV D,L",  "MOV D,M",  "MOC D,A",
            "MOV E,B",  "MOV E,C",  "MOV E,D",  "MOV E,E",  "MOV E,H",  "MOV E,L",  "MOV E,M",  "MOV E,A",
            "MOV H,B",  "MOV H,C",  "MOV H,D",  "MOV H,E",  "MOV H,H",  "MOV H,L",  "MOV H,M",  "MOV H,A",
            "MOV L,B",  "MOV L,C",  "MOV L,D",  "MOV L,E",  "MOV L,H",  "MOV L,L",  "MOV L,M",  "MOV L,A",
            "MOV M,B",  "MOV M,C",  "MOV M,D",  "MOV M,E",  "MOV M,H",  "MOV M,L",  "HLT",      "MOV M,A",
            "MOV A,B",  "MOV A,C",  "MOV A,D",  "MOV A,E",  "MOV A,H",  "MOV A,L",  "MOV A,M",  "MOV A,A",
            "ADD B",    "ADD C",    "ADD D",    "ADD E",    "ADD H",    "ADD L",    "ADD M",    "ADD A",
            "ADC B",    "ADC C",    "ADC D",    "ADC E",    "ADC H",    "ADC L",    "ADC M",    "ADC A",
            "SUB B",    "SUB C",    "SUB D",    "SUB E",    "SUB H",    "SUB L",    "SUB M",    "SUB A",
            "SBB B",    "SBB C",    "SBB D",    "SBB E",    "SBB H",    "SBB L",    "SBB M",    "SBB A",
            "ANA B",    "ANA C",    "ANA D",    "ANA E",    "ANA H",    "ANA L",    "ANA M",    "ANA A",
            "XRA B",    "XRA C",    "XRA D",    "XRA E",    "XRA H",    "XRA L",    "XRA M",    "XRA A",
            "ORA B",    "ORA C",    "ORA D",    "ORA E",    "ORA H",    "ORA L",    "ORA M",    "ORA A",
            "CMP B",    "CMP C",    "CMP D",    "CMP E",    "CMP H",    "CMP L",    "CMP L",    "CMP A",
            "RNZ",      "POP B",    "JNZ ",     "JMP ",     "CNZ ",     "PUSH B",   "ADI ",     "RST 0",
            "RZ",       "RET",      "JZ ",      "JMP ",     "CZ ",      "CALL ",    "ACI ",     "RST 1",
            "RNC",      "POP D",    "JNC ",     "OUT ",     "CNC ",     "PUSH D",   "SUI ",     "RST 2",
            "RC",       "RET",      "JC ",      "IN ",      "CC ",      "CALL ",    "SBI ",     "RST 3",
            "RPO",      "POP H",    "JPO ",     "XTHL",     "CPO ",     "PUSH H",   "ANI ",     "RST 4",
            "RPE",      "PCHL",     "JPE ",     "XCHG",     "CPE ",     "CALL ",    "XRI ",     "RST 5",
            "RP",       "POP PSW",  "JP ",      "DI",       "CP ",      "PUSH PSW", "ORI ",     "RST 6",
            "RM",       "SPHL",     "JM ",      "EI",       "CM ",      "CALL ",    "CPI ",     "RST 7"
        };

        public static byte[] instructionLengths = new byte[]
        {
            1, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 1,
            1, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 1,
            1, 3, 3, 1, 1, 1, 2, 1, 1, 1, 3, 1, 1, 1, 2, 1,
            1, 3, 3, 1, 1, 1, 2, 1, 1, 1, 3, 1, 1, 1, 2, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 3, 3, 3, 1, 2, 1, 1, 1, 3, 3, 3, 3, 2, 1,
            1, 1, 3, 2, 3, 1, 2, 1, 1, 1, 3, 2, 3, 3, 2, 1,
            1, 1, 3, 1, 3, 1, 2, 1, 1, 1, 3, 1, 3, 3, 2, 1,
            1, 1, 3, 1, 3, 1, 2, 1, 1, 1, 3, 1, 3, 3, 2, 1
        };

        public static byte currentInstructionLength
        {
            get { return instructionLengths[EmulatedSystem.memory.bytes[EmulatedSystem.cpu.registers.pc]]; }
        }

        public static string disassembleCurrentInstruction()
        {
            ushort pc = EmulatedSystem.cpu.registers.pc;
            byte opCode = EmulatedSystem.memory.bytes[pc];
            string x = mnemonics[opCode];

            if (instructionLengths[opCode] == 2)    // 8 bit immediate
            {
                x += EmulatedSystem.memory.bytes[pc + 1].ToString("X2");
                x += "h";
            }

            if (instructionLengths[opCode] == 3)    // 16 bit immediate
            {
                x += EmulatedSystem.memory.bytes[pc + 2].ToString("X2");
                x += EmulatedSystem.memory.bytes[pc + 1].ToString("X2");
                x += "h";
            }

            return x;
        }
    }
}
