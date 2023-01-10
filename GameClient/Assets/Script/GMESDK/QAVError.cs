using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AOT;


namespace GME
{
	public class QAVError
	{
		#region Interface
		public static int OK = 0x0;

        //For handling all error codes, just use != AV_OK
        //If you need to handle each type of error separately, pay attention to the type of error returned by the interface。
        //This error code has no clear meaning and is deprecated for the versions later than 2.4.

        public static int ERR_REPETITIVE_OPERATION = 0x3E9;      //DEC 1001 Repeat operation. This error is returned if you try to do the same operation again after you have already done something
        public static int ERR_EXCLUSIVE_OPERATION = 0x3EA;       //DEC 1002 Mutually exclusive operation. This error is returned when an operation of the same type is performed
        public static int ERR_HAS_IN_THE_STATE = 0x3EB;          //DEC 1003 Already in the desired state and mo more operations required. If the device is already turned on and you try to turn it on again,this error code will be returned.
        public static int ERR_INVALID_ARGUMENT = 0x3EC;          //DEC 1004 Error parameters
        public static int ERR_TIMEOUT = 0x3ED;                   //DEC 1005 Operation timed out
        public static int ERR_NOT_IMPLEMENTED = 0x3EE;          //DEC 1006 Function not implemented
        public static int ERR_NOT_IN_MAIN_THREAD = 0x3EF;       //DEC 1007 Operations are not performed in the main thread

        public static int ERR_CONTEXT_NOT_START = 0x44D;    //DEC 1101 AVContext is not started
        public static int ERR_ROOM_NOT_EXIST = 0x4B1;       //DEC 1201 The room does not exist

        public static int ERR_DEVICE_NOT_EXIST = 0x515;  //DEC 1301 Device does not exist

        public static int ERR_SERVER_FAILED = 0x2711;                         //DEC 10001 Server internal error
        public static int ERR_SERVER_NO_PERMISSION = 0x2713;                  //DEC 10003 Permission denied
		public static int ERR_SERVER_REQUEST_ROOM_ADDRESS_FAIL = 0x2714;      //DEC 10004 Failed to access the room address
        public static int ERR_SERVER_CONNECT_ROOM_FAIL = 0x2715;              //DEC 10005 Failed to connect to room
        public static int ERR_SERVER_FREE_FLOW_AUTH_FAIL = 0x2716;           //DEC 10006 In streaming free mode,the signature verification of streaming free will fail,resulting in the failure to obtain the room address
        public static int ERR_SERVER_ROOM_DISSOLVED = 0x2717;                 //DEC 10007 In game application room for more than 90 minutes, resulting in forced offline.


        public static int ERR_IMSDK_UNKNOWN = 0x1B57;           //DEC 6999  IMSDK internal error
        public static int ERR_IMSDK_TIMEOUT = 0x1B58;           //DEC 7000  IMSDK internal error
        public static int ERR_HTTP_REQ_FAIL = 0x1B59;           //DEC 7001  Http request error

        public static int AV_ERR_3DVOICE_ERR_FILE_DAMAGED = 7002;
        public static int AV_ERR_3DVOICE_ERR_NOT_INITED = 7003;

        public static int AV_ERR_NET_REQUEST_FALLED = 7004;
        public static int AV_ERR_CHARGE_OVERDUE     = 7005;
        public static int AV_ERR_AUTH_FIALD         = 7006;
        public static int AV_ERR_IN_OTHER_ROOM      = 7007;
        public static int AV_ERR_DISSOLVED_OVERUSER = 7008;
        public static int AV_ERR_NO_PERMISSION      = 7009;
        public static int AV_ERR_FILE_CANNOT_ACCESS = 7010;
        public static int AV_ERR_FILE_DAMAGED       = 7011;
        public static int AV_ERR_SERVICE_NOT_OPENED = 7012;
        public static int AV_ERR_USER_CANCELED      = 7013;
        public static int AV_ERR_LOAD_LIB_FAILED    = 7014;
        public static int AV_ERR_SDK_NOT_FULL_UPDATE= 7015;//Not all files are updated when the SDK is upgraded. As a result, some modules do not match
        public static int AV_ERR_ROOMMANAGER_TIMESTAMP_CHECK_FAIL = 7016;
		public static int AV_ERR_ASR_CONNECT_CLOSED = 7017;
		public static int AV_ERR_MUTESWITCH_DECTECT_ERR =7018;//iOS mute switch detection error;;
        public static int AV_ERR_DB_ERROR           = 7019;    // Database error
        public static int AV_ERR_SYSTEM_INTERNAL_ERROR = 7020; // 系统内部错误
        public static int AV_ERR_INVALID_REQ        = 7021;    //  Invalid request
        public static int AV_ERR_BUS_ERROR          = 7022;    // The service is not supported or enabled



        public static int ERR_3DVOICE_ERR_FILE_DAMAGED  =0x1B5A;//7002  3d voice model file is damaged.
		public static int ERR_3DVOICE_ERR_NOT_INITED    =0x1B5B;//7003 should call InitSpatializer first

		public static int ERR_UNKNOWN = 0x10000;                 //DEC 65536 //Unknown error, requires log analysis


        public static int ERR_ACC_OPENFILE_FAILED = 0xFA1;                  //DEC 4001 Failed to open file accompaniment
        public static int ERR_ACC_FILE_FORAMT_NOTSUPPORT = 0xFA2;           //DEC 4002 Accompaniment file format not supported
        public static int ERR_ACC_DECODER_FAILED = 0xFA3;                     //DEC 4003 Accompaniment decoding failure
        public static int ERR_ACC_BAD_PARAM = 0xFA4;                         //DEC 4004 Wrong accompaniment parameters
        public static int ERR_ACC_MEMORY_ALLOC_FAILED = 0xFA5;              //DEC 4005 Accompaniment memory allocation failed
        public static int ERR_ACC_CREATE_THREAD_FAILED = 0xFA6;             //DEC 4006 Failed to create the accompaniment thread
        public static int ERR_ACC_NOT_STARTED = 0xFA7;                     //DEC 4007 Accompaniment not started

        public static int ERR_EFFECT_OPENFILE_FAILED         =  0XFD3;   ///DEC 4051 Failed to open file
		public static int ERR_EFFECT_FILE_FORAMT_NOTSUPPORT  =  0XFD4; ///DEC 4052 Unsupported file format
		public static int ERR_EFFECT_DECODER_FAILED          =  0XFD5; ///DEC 4053 Decoding failure
		public static int ERR_EFFECT_BAD_PARAM               =  0XFD6; ///DEC 4054 Parameter error
		public static int ERR_EFFECT_MEMORY_ALLOC_FAILED     =  0XFD7;  ///DEC 4055 Memory allocation failure
		public static int ERR_EFFECT_CREATE_THREAD_FAILED    =  0XFD8; ///DEC 4056 Failed to create thread
		public static int ERR_EFFECT_STATE_ILLIGAL           =  0XFD9;  ///DEC 4057 State of illegal

        // 实时语音录制相关
        public static int ERR_RECORD_OPENFILE_FAILED = 0x1389;                  ///<DEC 5001 Failed to open file
		public static int ERR_RECORD_FILE_FORAMT_NOTSUPPORT = 0x138A;             ///<DEC 5002 Unsupported file format
		public static int ERR_RECORD_DECODER_FAILED = 0x138B;                     ///<DEC 5003 Decoding failure
		public static int ERR_RECORD_BAD_PARAM = 0x138C;                          ///<DEC 5004 Parameter error
		public static int ERR_RECORD_MEMORY_ALLOC_FAILED = 0x138D;               ///<DEC 5005 Memory allocation failure
		public static int ERR_RECORD_CREATE_THREAD_FAILED = 0x138E;               ///<DEC 5006 Failed to create thread
		public static int ERR_RECORD_STATE_ILLIGAL = 0x138F;                       ///<DEC 5007 Illegal statement

        // 离线语音录制相关
        public static int ERR_VOICE_RECORD_PARAM_NULL = 0x1001;         //DEC 4097  param null
		public static int ERR_VOICE_RECORD_INIT_ERR = 0x1002;           //DEC 4098 Init Error
		public static int ERR_VOICE_RECORD_RECORDING_ERR = 0x1003;      //DEC 4099 now is recording, can't do other operator
		public static int ERR_VOICE_RECORD_NODATA_ERR = 0x1004;         //DEC 4100 nodata
		public static int ERR_VOICE_RECORD_OPENFILE_ERR = 0x1005;       //DEC 4101 open a file err
		public static int ERR_VOICE_RECORD_PERMISSION_MIC_ERR = 0x1006; //DEC 4102 you have not right to access micphone in android
		public static int ERR_VOICE_RECORD_AUDIO_TOO_SHORT = 0x1007;    //DEC 4103 less than 1000 ms
		public static int ERR_VOICE_RECORD_RECORD_NOT_START = 0x1008;	//DEC 4104 record not start
		
		public static int ERR_VOICE_UPLOAD_FILE_ACCESSERROR = 0x2001;       //DEC 8193 Read File Failed
		public static int ERR_VOICE_UPLOAD_SIGN_CHECK_FAIL = 0x2002;        //DEC 8194 Sign Check Failed maybe network or appid mismatch
		public static int ERR_VOICE_UPLOAD_COS_INTERNAL_FAIL = 0x2003;           //DEC 8195 Network return error, watch log
		public static int ERR_VOICE_UPLOAD_GET_TOKEN_NETWORK_FAIL = 0x2004;  //DEC 8196 connect server failed
		public static int ERR_VOICE_UPLOAD_SYSTEM_INNER_ERROR = 0x2005;      //DEC 8197 the response data is null
		public static int ERR_VOICE_UPLOAD_RSP_DATA_DECODE_FAIL = 0x2006;   //DEC 8198 decode response data failed
		public static int ERR_VOICE_UPLOAD_APPINFO_UNSET = 0x2008;          //DEC 8200 app info has not set
		
		//public static int ERR_VOICE_UPLOAD_NETWORK_FAIL = 0x2003;          deprecated 
		//public static int ERR_VOICE_UPLOAD_GET_SIGN_NETWORK_FAIL = 0x2004; deprecated 
		//public static int ERR_VOICE_UPLOAD_GET_SIGN_RSP_NULL = 0x2005;     deprecated 
		//public static int ERR_VOICE_UPLOAD_GET_SIGN_RSP_INVALID = 0x2006;  deprecated 
		//public static int ERR_VOICE_UPLOAD_SIGN_CHECK_EXPIRED = 0x2007;    deprecated 
		
		
		public static int ERR_VOICE_DOWNLOAD_FILE_ACCESSERROR = 0x3001;         //DEC 12289 Write File Failed
		public static int ERR_VOICE_DOWNLOAD_SIGN_CHECK_FAIL = 0x3002;          //DEC 12290 Sign Check Failed maybe network or appid mismatch
		public static int ERR_VOICE_DOWNLOAD_COS_INTERNAL_FAIL = 0x3003;             //DEC 12291 Network return error, watch log
		public static int ERR_VOICE_DOWNLOAD_REMOTEFILE_ACCESSERROR = 0x3004;   //DEC 12292 Remote File Not Exist
		public static int ERR_VOICE_DOWNLOAD_GET_SIGN_NETWORK_FAIL = 0x3005;    //DEC 12293 connect server failed
		public static int ERR_VOICE_DOWNLOAD_SYSTEM_INNER_ERROR = 0x3006;        //DEC 12294 the response data is null
		public static int ERR_VOICE_DOWNLOAD_GET_SIGN_RSP_DATA_DECODE_FAIL = 0x3007;     //DEC 12295 decode response data failed
		public static int ERR_VOICE_DOWNLOAD_APPINFO_UNSET = 0x3009;            //DEC 12297 app info has not set
		
		//public static int ERR_VOICE_DOWNLOAD_NETWORK_FAIL = 0x3003;            deprecated 
		//public static int ERR_VOICE_DOWNLOAD_GET_SIGN_RSP_NULL = 0x3006;       deprecated 
		//public static int ERR_VOICE_DOWNLOAD_GET_SIGN_RSP_INVALID = 0x3007;    deprecated 
		//public static int ERR_VOICE_DOWNLOAD_SIGN_CHECK_EXPIRED = 0x3008;      deprecated 
		
		public static int ERR_VOICE_PLAYER_INIT_ERR = 0x5001;           //DEC 20481 Init Error
		public static int ERR_VOICE_PLAYER_PLAYING_ERR = 0x5002;        //DEC 20482 now is playing, can't do other operator
		public static int ERR_VOICE_PLAYER_PARAM_NULL = 0x5003;         //DEC 20483 param null
		public static int ERR_VOICE_PLAYER_OPENFILE_ERR = 0x5004;       //DEC 20484 open a file err
		public static int ERR_VOICE_PLAYER_NOT_START_ERR = 0x5005;  	//DEC 20485 play file not start

		public static int ERR_VOICE_S2T_INTERNAL_ERROR = 0x8001;        // DEC 32769 internal error
		public static int ERR_VOICE_S2T_NETWORK_FAIL = 0x8002;          // DEC 32770 connect server failed
		public static int ERR_VOICE_S2T_RSP_DATA_DECODE_FAIL = 0x8004;  // DEC 32772 decode response data failed
		public static int ERR_VOICE_S2T_APPINFO_UNSET = 0x8006;         // DEC 32774 app info has not set
		public static int ERR_VOICE_STREAMIN_RECORD_SUC_REC_FAIL    = 0x8007;     //The streaming voice failed to be transferred to text. The audio file failed to be uploaded. The recording succeeded and was saved locally
        public static int ERR_VOICE_S2T_SIGN_CHECK_FAIL = 0x8008;      // authbuffer verification failed
        public static int ERR_VOICE_STREAMIN_UPLOADANDRECORD_SUC_REC_FAIL    = 0x8009;     //The voice transfer failed.The recording was saved locally, and the audio file was uploaded to the server
        public static int ERR_VOICE_S2T_PARAM_NULL                                   = 0x8010; //file ID is NULL
		public static int ERR_VOICE_S2T_AUTO_SPEECH_REC_ERROR                        = 0x8011; //AudioFileDecode error,asr error,http param error,etc
		public static int ERR_VOICE_ERR_VOICE_STREAMIN_RUNING_ERROR					 = 0x8012;
		public static int ERR_VOICE_ERR_VOICE_S2T_TRNSLATE_SERVICE_NOT_AVALIABLE     = 0x8013; //Translate function service not avaliable
        public static int ERR_VOICE_ERR_VOICE_S2T_TRNSLATE_LANGUAGE_NOT_SUPPORTED    = 0x8014; //Translate language not supported

		public static int ERR_VOICE_ERR_VOICE_STREAMING_ASR_ERROR                     = 50012; //asr error

        public static int AV_ERR_VOICE_NOT_INIT = 740000;
        public static int AV_ERR_VOICE_NOT_SET = 740001;
        public static int AV_ERR_VOICE_INIT_FAIL = 740002;
        public static int AV_ERR_VOICE_CALL_FAIL = 740003;
        public static int AV_ERR_VOICE_LOAD_FAIL = 740004;
        
        public static int AV_ERR_FACE_TRACK_LOAD_FAIL = 740010;
        public static int AV_ERR_FACE_TRACK_INIT_FAIL = 740011;
        public static int AV_ERR_FACE_TRACK_CREATE_FAIL = 740012;

        //public static int ERR_VOICE_S2T_RSP_DATA_NULL = 0x8003;         		deprecated 
        //public static int ERR_VOICE_S2T_SIGN_CHECK_EXPIRED = 0x8005;   		deprecated 
        //public static int ERR_VOICE_V2T_SIGN_CHECK_FAIL    = 0x8008; 			deprecated 
        public static string GMESDK_VERSION_2_9_5_83c5106c = "2_9_5_83c5106c";
        #endregion
    }
}