using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Collections.ObjectModel;


namespace CSLibrary.Constants {
    public enum TAG_BACKSCATTERED_ERROR : byte {
        OTHER_ERROR,
        MEMORY_OVERRUN = 0x3,
        MEMORY_LOCKED = 0x4,
        INSUFFICIENT_POWER = 0xB,
        NON_SPECIFIC_ERROR = 0xF
    }

    enum RFID_PACKET_TYPE : ushort {
        COMMAND_BEGIN = 0,
        COMMAND_END,
        ANTENNA_CYCLE_BEGIN,
        ANTENNA_BEGIN,
        ISO18K6C_INVENTORY_ROUND_BEGIN,
        ISO18K6C_INVENTORY,
        ISO18K6C_TAG_ACCESS,
        ANTENNA_CYCLE_END,
        /// <summary>
        /// The antenna-end packet indicates that the radio has stopped using a particular 
        /// antenna for the current cycle.  
        /// </summary>
        ANTENNA_END,
        /// <summary>
        /// The ISO 18000-6C inventory-round-end packet indicates that an ISO 18000-6C 
        /// inventory round has ended on an antenna. 
        /// </summary>
        ISO18K6C_INVENTORY_ROUND_END,
        INVENTORY_CYCLE_BEGIN,
        /// <summary>
        /// The inventory-cycle-end packet indicates that an inventory round has ended on an 
        /// antenna. 
        /// </summary>
        INVENTORY_CYCLE_END,
        /// <summary>
        /// The Carrier info packet is sent by the Intel® R1000 Firmware whenever Transmit CW 
        /// is turned on and whenever it is turned off. The purpose is to provide timing 
        /// information frequency channel use information to the host application. 
        /// </summary>
        CARRIER_INFO,
        /// <summary>
        /// The Cycle configuration event packet is sent when the Intel® R1000 Firmware 
        /// performs a cycle granular configuration adjustment. 
        /// </summary>
        CYCCFG_EVT,
        /* The packet types for the diagnostics packets.                          */
        /// <summary>
        /// Reserved
        /// </summary>
        RES0 = 4096,//PktConstants.RFID_PACKET_CLASS_BASE(RFID_PACKET_CLASS.DIAGNOSTICS),
        /// <summary>
        /// Reserved
        /// </summary>
        RES1,
        /// <summary>
        /// Reserved
        /// </summary>
        RES2,
        /// <summary>
        /// Reserved
        /// </summary>
        RES3,
        /// <summary>
        /// The ISO 18000-6C inventory-round-begin-diagnostics packet appears at the beginning 
        /// of an ISO 18000-6C inventory round and contains diagnostics information related to 
        /// the inventory round that is about to commence. 
        /// </summary>
        ISO18K6C_INVENTORY_ROUND_BEGIN_DIAGS,
        /// <summary>
        /// The ISO 18000-6C inventory-round-end-diagnostics packet appears at the end of an 
        /// ISO 18000-6C inventory round and contains diagnostics information related to the 
        /// inventory round that has just completed. 
        /// </summary>
        ISO18K6C_INVENTORY_ROUND_END_DIAGS,
        /// <summary>
        /// The ISO 18000-6C inventory-response diagnostics packet is used to convey 
        /// diagnostics information for the tag during the ISO 18000-6C inventory. 
        /// </summary>
        ISO18K6C_INVENTORY_DIAGS,
        RES4,
        INVENTORY_CYCLE_END_DIAGS,
        NONCRITICAL_FAULT = 8192 //PktConstants.RFID_PACKET_CLASS_BASE(RFID_PACKET_CLASS.STATUS),
    }

    enum RFID_COMMAND_TYPE_18K6C : uint {
        INVENTORY = 0x0000000F,
        READ = 0x00000010,
        WRITE = 0x00000011,
        /// <summary>
        /// ISO 18000-6C Lock
        /// </summary>
        LOCK = 0x00000012,
        /// <summary>
        /// ISO 18000-6C Kill
        /// </summary>
        KILL = 0x00000013
    }

    public enum RFID_18K6C : byte {
        QUERYREP = 0x00,
        ACK = 0x01,
        QUERY = 0x08,
        QUERYADJ = 0x09,
        SELECT = 0x0A,
        /// <summary>
        /// ISO 18000-6C Nak
        /// </summary>
        NAK = 0xC0,
        /// <summary>
        /// ISO 18000-6C request RN
        /// </summary>
        REQRN = 0xC1,
        /// <summary>
        /// ISO 18000-6C Read
        /// </summary>
        READ = 0xC2,
        /// <summary>
        /// ISO 18000-6C Write
        /// </summary>
        WRITE = 0xC3,
        /// <summary>
        /// ISO 18000-6C Kill
        /// </summary>
        KILL = 0xC4,
        /// <summary>
        /// ISO 18000-6C Lock
        /// </summary>
        LOCK = 0xC5,
        /// <summary>
        /// ISO 18000-6C Access
        /// </summary>
        ACCESS = 0xC6,
        /// <summary>
        /// ISO 18000-6C Block write
        /// </summary>
        BLOCKWRITE = 0xC7,
        /// <summary>
        /// ISO 18000-6C Block erase
        /// </summary>
        BLOCKERASE = 0xC8,
        /// <summary>
        /// ISO 18000-6C QT command
        /// </summary>
        QT         = 0xE0,
        /// <summary>
        /// Unknown
        /// </summary>
        UNKNOWN = 0xff
    }
    /// <summary>
    /// Tag access enum Result
    /// </summary>
    public enum RFID_ACCESS : byte
    {
        /// <summary>
        /// general error (catch-all for errors not covered by codes) 
        /// </summary>
        GENERAL_ERR = 0x00,
        /// <summary>
        /// specified memory location does not exist of the PC value is not supported by the tag 
        /// </summary>
        MEMORY_LOCATION_NOT_EXIST = 0x03,
        /// <summary>
        /// specified memory location is locked and/or permalocked and is not writeable
        /// </summary>
        PERMISSION_DENIED = 0x04,
        /// <summary>
        /// tag has insufficient power to perform the memory write
        /// </summary>
        INSUFFICIENT_POWER_TO_WRITE = 0x0B,
        NOT_SUPPORTED = 0x0F,
        ACK_TIMEOUT = 0x10,
        CRC_INVALID,
        WRITE_VERIFY_FAILED = 0xD1,
        /// <summary>
        /// Problem transmitting tag command. 
        /// </summary>
        PROBLEM_TRANSMITTING_TAG_CMD = 0xD2,
        /// <summary>
        /// CRC error on tag response to a write. 
        /// </summary>
        CRC_INVALID_ON_WRITE = 0xD3,
        /// <summary>
        /// CRC error on the read packet when verifying the write. 
        /// </summary>
        CRC_INVALID_ON_READ = 0xD4,
        /// <summary>
        /// Maximum retry's on the write exceeded. 
        /// </summary>
        WRITE_RETRY_EXCEEDED = 0xD5,
        /// <summary>
        /// Failed waiting for read data from tag, possible timeout. 
        /// </summary>
        READ_TIMEOUT = 0xD6,
        /// <summary>
        /// Failure requesting a new tag handle. 
        /// </summary> 
        REQ_TAG_HANDLE_FAILED = 0xD7,
        /// <summary>
        /// Error waiting for tag response, possible timeout. 
        /// </summary>
        RESP_TIMEOUT = 0xDA,
        /// <summary>
        /// CRC error on tag response to a kill. 
        /// </summary>
        CRC_INVALID_ON_KILL = 0xDB,
        /// <summary>
        /// Problem transmitting 2nd half of tag kill. 
        /// </summary>
        PROBLEM_TRANSMITTING_KILL_CMD = 0xDC,
        /// <summary>
        /// Tag responded with an invalid handle on first kill command. 
        /// </summary>
        INVALID_HANDLE_ON_KILL_CMD = 0xDD,
        /// <summary>
        /// can't determine error type
        /// </summary>
        UNKNOWN,
        /// <summary>
        /// access success
        /// </summary>
        SUCCESS = 0x1
    }

#if NOUSE
    public class PktConstants
    {
        /* A packet type number is comprised of an 8-bit class and a 12-bit packet    */
        /* number.  The layout of the packet type number is 0xCNNN where C is the     */
        /* class and N is the number within the class.                                */

        /* The macros help in creating and breaking apart packet types from/into their*/
        /* their component values.                                                    */
        public readonly uint RFID_PACKET_CLASS_MASK = 0x000F;
        public readonly int RFID_PACKET_CLASS_SHIFT = 12;
        public readonly uint RFID_PACKET_NUMBER_MASK = 0x0FFF;

        /* Creates the base packet type number for a class.  The base packet type     */
        /* number is incremented to obtain packet type numbers for subsequent packets.*/
        public uint RFID_PACKET_CLASS_BASE(uint c)
        {
            return ((INT16U)((c) << RFID_PACKET_CLASS_SHIFT));
        }

        /* Extracts the RFID class or number from a packet type (t)                   */
        public uint EXTRACT_RFID_PACKET_CLASS(uint t)
        {
            return (((t) >> RFID_PACKET_CLASS_SHIFT) & RFID_PACKET_CLASS_MASK);
        }
        public uint EXTRACT_RFID_PACKET_NUMBER(uint t)
        {
            return ((t) & RFID_PACKET_NUMBER_MASK);
        }

        /* Macros to make it easier to extract the bit fields out of the command      */
        /* begin flags field (i.e., cmn.flags)                                        */
        public uint RFID_COMMAND_IN_CONTINUOUS_MODE(uint f)
        {
            return ((f) & 0x01);
        }
        public uint RFID_COMMAND_NOT_IN_CONTINUOUS_MODE(uint f)
        {
            return (~(RFID_COMMAND_IN_CONTINUOUS_MODE(f)));
        }
        /* Macros to make it easier to extract the bit fields out of the singulation  */
        /* parameters field (i.e., sing_params).  NOTE - since the packet format      */
        /* specifies that 16-bit fields are transmitted in little endian, ensure that */
        /* the field is byte swapped, if necessary, for the host system before        */
        /* applying any of the macros.                                                */
        public uint RFID_SINGULATION_PARMS_CURRENT_Q(uint sing)
        {
            return ((sing) & 0x000F);
        }
        public uint RFID_SINGULATION_PARMS_CURRENT_SLOT(uint sing)
        {
            return (((sing) >> 4) & 0x1ffff);
        }
        public uint RFID_SINGULATION_PARMS_INVENTORY_A(uint sing)
        {
            return (~(((sing) >> 21) & 0x0001));
        }
        public uint RFID_SINGULATION_PARMS_INVENTORY_B(uint sing)
        {
            return (((sing) >> 21) & 0x0001);
        }
        public uint RFID_SINGULATION_PARMS_CURRENT_RETRY(uint sing)
        {
            return (((sing) >> 22) & 0xff);
        }
        /* Macros to make it easier to extract the bit fields out of the 18k6c        */
        /* inventory flags field (i.e., cmn.flags)                                    */
        public uint RFID_18K6C_INVENTORY_CRC_IS_INVALID(uint f)
        {
            return ((f) & 0x01);
        }
        public uint RFID_18K6C_INVENTORY_CRC_IS_VALID(uint f)
        {
            return ~(RFID_18K6C_INVENTORY_CRC_IS_INVALID(f));
        }
        public uint RFID_18K6C_INVENTORY_PADDING_BYTES(uint f)
        {
            return (((f) >> 6) & 0x03);
        }

        /* Macros to make it easier to extract the bit fields out of the 18k6c        */
        /* inventory diagnostics protocol parameters (i.e., prot_parms) field.  NOTE -*/
        /* since the packet format specifies that 32-bit fields are transmitted in    */
        /* little endian, ensure that the field is byte swapped, if necessary, for the*/
        /* host system before applying any of the macros.                             */
        public uint RFID_18K6C_PROTOCOL_PARMS_Q(uint parms)
        {
            return ((parms) & 0x0000000F);
        }
        public uint RFID_18K6C_PROTOCOL_PARMS_C(uint parms)
        {
            return (((parms) & 0x00000070) >> 4);
        }
        public uint RFID_18K6C_PROTOCOL_PARMS_TARI(uint parms)
        {
            return (((parms) & 0x0000FF00) >> 8);
        }

        /* Macros to make it easier to extract the bit fields out of the 18k6c        */
        /* tag access flags (i.e., cmn.flags) field                                   */
        public uint RFID_18K6C_TAG_ACCESS_ERROR(uint f)
        {
            return ((f) & 0x01);
        }
        public uint RFID_18K6C_TAG_ACCESS_NOERROR(uint f)
        {
            return ~(RFID_18K6C_TAG_ACCESS_ERROR(f));
        }
        public uint RFID_18K6C_TAG_BACKSCATTER_ERROR(uint f)
        {
            return ((f) & 0x02);
        }
        public uint RFID_18K6C_TAG_BACKSCATTER_NOERROR(uint f)
        {
            return ~(RFID_18K6C_TAG_BACKSCATTER_ERROR(f));
        }
        public uint RFID_18K6C_TAG_ACCESS_TIMEOUT(uint f)
        {
            return ((f) & 0x04);
        }
        public uint RFID_18K6C_TAG_ACCESS_NOTIMEOUT(uint f)
        {
            return ~(RFID_18K6C_TAG_ACCESS_TIMEOUT(f));
        }
        public uint RFID_18K6C_TAG_ACCESS_CRC_INVALID(uint f)
        {
            return ((f) & 0x08);
        }
        public uint RFID_18K6C_TAG_ACCESS_CRC_VALID(uint f)
        {
            return ~(RFID_18K6C_TAG_ACCESS_CRC_INVALID(f));
        }
        public uint RFID_18K6C_TAG_ACCESS_PADDING_BYTES(uint f)
        {
            return (((f) >> 6) & 0x3);
        }


        public readonly uint CWFLAGS_CWON = 0x0001;
        public readonly uint CWFLAGS_CWOFF = 0x0000;
        public uint CARRIER_INFO_IS_CWON(uint cw_flags)
        { return (cw_flags & CWFLAGS_CWON); }
        public uint CARRIER_INFO_IS_CWOFF(uint cw_flags)
        { return (uint)((cw_flags & CWFLAGS_CWON) == 0 ? 1 : 0); }
        public uint CARRIER_INFO_SET_CWON(uint cw_flags)
        { return (cw_flags |= CWFLAGS_CWON); }
        public uint CARRIER_INFO_SET_CWOFF(uint cw_flags)
        { return (cw_flags &= ~CWFLAGS_CWON); }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    class PacketBitMap
    {
        // Bit=mapped data for flags field of the BegCmd packet
        public readonly BitVector32.Section continuousMode = BitVector32.CreateSection(0x01);

        /// Bit-mapped data for flags field of INVENTORY packet
        public static readonly BitVector32.Section crcResult = BitVector32.CreateSection(0x01);
        // Bit 0	CRC valid flag:

        public static readonly BitVector32.Section reserved = BitVector32.CreateSection(31, crcResult);
        // bit 1-5	Reserved.  Read as zero.

        public readonly BitVector32.Section paddingBytes = BitVector32.CreateSection(3, reserved);
        // bits 6 and 7 number of padding bytes added to end of INVENTORY data 


        /// Bit-mapped data for flags field of ISO_18000_6C Tag Access packet
        public static readonly BitVector32.Section accessErrorFlag = BitVector32.CreateSection(0x01);
        public static readonly BitVector32.Section accessTagErrFlag = BitVector32.CreateSection(0x01, accessErrorFlag);
        public static readonly BitVector32.Section accessAckTOFlag = BitVector32.CreateSection(0x01, accessTagErrFlag);
        public static readonly BitVector32.Section accessCRCFlag = BitVector32.CreateSection(0x01, accessAckTOFlag);
        public static readonly BitVector32.Section accessReserved = BitVector32.CreateSection(0x03, accessCRCFlag);
        public readonly BitVector32.Section accessPadding = BitVector32.CreateSection(0x03, accessReserved);


        // Bit-mapped data for sing_params field of inv_rnd_beg_diag packet
        public static readonly BitVector32.Section CurrentQValue = BitVector32.CreateSection(0x0f);
        public static readonly BitVector32.Section CurrentSlot1 = BitVector32.CreateSection(0xff, CurrentQValue);
        public static readonly BitVector32.Section CurrentSlot2 = BitVector32.CreateSection(0x1ff, CurrentSlot1);
        public static readonly BitVector32.Section InventoriedFlag = BitVector32.CreateSection(0x01, CurrentSlot2);
        public readonly BitVector32.Section RetryCount = BitVector32.CreateSection(0x01ff, InventoriedFlag);
        //Bit	0	Inventoried flag value: 

 
        /*
                    public readonly BitVector32.Section Session			= BitVector32.CreateSection(0x03, InventoriedFlag);
                    //2:1	Inventory session:

                    enum InventorySession
                    {
                        S0 = 0x00,	//00 ?Use session S0 for inventory round
                        S1 = 0x01,	//01 ?Use session S1 for inventory round
                        S2 = 0x02,	//10 ?Use session S2 for inventory round
                        S3 = 0x03,	//11 ?Use session S3 for inventory round
                    }

                    public string InventorySessionName(int val)
                    {
                        if (Enum.IsDefined(typeof(InventorySession), val))
                        {
                            switch ((InventorySession)val)
                            {
                                case InventorySession.S0:
                                    return "S0";

                                case InventorySession.S1:
                                    return "S1";

                                case InventorySession.S2:
                                    return "S2";

                                case InventorySession.S3:
                                    return "S3";
                            }
                        }
                        return "?";
                    }


                    public readonly BitVector32.Section SelectedState	= BitVector32.CreateSection(0x03, Session);
                    //4:3	Selected flag value:

                    enum SelectedStateValues
                    {
                        Either	= 0x00,	//00 ?Tags with selected flag in either state chosen for inventory round
                        Set		= 0x02,	//10 ?Tags with selected flag set chosen for inventory round
                        Unset	= 0x03,	//11 ?Tags with selected flag unset chosen for inventory round
                    }

                    public string SelectedStateName(int val)
                    {
                        if (Enum.IsDefined(typeof(SelectedStateValues), val))
                        {
                            switch ((SelectedStateValues)val)
                            {
                                case SelectedStateValues.Either:
                                    return "Any";

                                case SelectedStateValues.Set:
                                    return "Set";

                                case SelectedStateValues.Unset:
                                    return "Unset";
                            }
                        }
                        return "Unknown";
                    }
                    public readonly BitVector32.Section DivideRatio		= BitVector32.CreateSection(0x01, SelectedState);
                    //5	ISO 18000-6C tag-to-radio calibration divide ratio used for inventory round:

                    enum DivideRatioValues
                    {
                        Eight = 0,			//0 ?Divide ratio = 8
                        SixtyfourOverThree = 1, //1 ?Divide ratio = 64/3
                    }

                    public string DivideRatioName(int val)
                    {
                        if (Enum.IsDefined(typeof(DivideRatioValues), val))
                        {
                            switch ((DivideRatioValues)val)
                            {
                                case DivideRatioValues.Eight:
                                    return "8";

                                case DivideRatioValues.SixtyfourOverThree:
                                    return "64/3";
                            }
                        }
                        return "?";
                    }

                    public readonly BitVector32.Section SubcarrierCycles = BitVector32.CreateSection(0x03, DivideRatio);
                    //7:6	ISO 18000-6C number of subcarrier cycles per bin in Miller sequence:

                    enum SubcarrierCyclesValues
                    {
                        FMO = 0x00,	//00 ?1 bit (FMO)
                        M2  = 0x01,	//01 ?2 bits (M=2)
                        M4  = 0x02,	//10 ?4 bits (M=4)
                        M8  = 0x03, //11 ?8 bits (M=8}
                    }

                    public string SubcarrierCyclesNames(int val)
                    {
                        if (Enum.IsDefined(typeof(SubcarrierCyclesValues), val))
                        {
                            switch ((SubcarrierCyclesValues)val)
                            {
                                case SubcarrierCyclesValues.FMO:
                                    return "FM0";

                                case SubcarrierCyclesValues.M2:
                                    return "M=2";

                                case SubcarrierCyclesValues.M4:
                                    return "M=4";

                                case SubcarrierCyclesValues.M8:
                                    return "M=8";
                            }
                        }
                        return "?";
                    }


                    public readonly BitVector32.Section PilotTone = BitVector32.CreateSection(0x01, SubcarrierCycles);
                    //8	ISO 18000-6C tag-to-radio preamble flag:

                    enum PilotToneValues
                    {
                        NoPilotTone = 0,	 //0 ?No pilot tone prepended to tag-to-radio preamble
                        PrependPilotTone = 1,	//1 ?Pilot tone prepended to tag-to-radio preamble
                    }

                    public string PilotToneNames(int val)
                    {
                        if (Enum.IsDefined(typeof(PilotToneValues), val))
                        {
                            switch ((PilotToneValues)val)
                            {
                                case PilotToneValues.NoPilotTone:
                                    return "Omit";

                                case PilotToneValues.PrependPilotTone:
                                    return "Add";
                            }
                        }
                        return "Unknown";
                    }

                    public readonly BitVector32.Section InitalQValue		= BitVector32.CreateSection(0x0f, PilotTone);
                    //12:9	Initial Q value

                    //15:13	Reserved.  Read as zero.
        */


        // Bit-mapped data for sing_stats field of inv_rnd_end_diag packet
        public static readonly BitVector32.Section singulationCollisions = BitVector32.CreateSection(0x7fff);
        // 15:0	Number of tag singulation collisions during inventory round.

        public static readonly BitVector32.Section hack = BitVector32.CreateSection(0x01, singulationCollisions);

        public static readonly BitVector32.Section minimumQValue = BitVector32.CreateSection(0x0f, hack);
        // 19:16	Minimum Q value during inventory round.

        public static readonly BitVector32.Section maximumQValue = BitVector32.CreateSection(0x0f, minimumQValue);
        //23:20	Maximum Q value during inventory round.

        //31:24	Reserved.  Read as zero.
      
    }
#endif
}
