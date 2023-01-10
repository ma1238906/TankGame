using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace GME
{
	public enum ITMGRoomType
	{
        ITMG_ROOM_TYPE_FLUENCY = 1,//Smooth sound quality
        ITMG_ROOM_TYPE_STANDARD = 2,//Good sound quality
        ITMG_ROOM_TYPE_HIGHQUALITY = 3,//HD sound quality
    };

	public enum ITMG_MAIN_EVENT_TYPE {
        ITMG_MAIN_EVENT_TYPE_NUMBER_OF_USERS_UPDATE = 7,// Number of users in current room
        ITMG_MAIN_EVENT_TYPE_NUMBER_OF_AUDIOSTREAMS_UPDATE = 8,// Number of audioStreams in current room
        ITMG_MAIN_EVENT_TYPE_SWITCH_ROOM = 13,//Notification of room switched
        ITMG_MAIN_EVENT_TYPE_SERVER_AUDIO_ROUTE_EVENT = 1091,
        ITMG_MAIN_EVENT_TYPE_CUSTOMDATA_UPDATE = 1092,
        ITMG_MAIN_EVENT_TYPE_REALTIME_ASR = 1093,
        ITMG_MAIN_EVENT_TYPE_AGE_DETECTED = 1096,
        ITMG_MAIN_EVNET_TYPE_ROOM_MANAGEMENT_OPERATOR = 6000,// RoomManager event
        ITMG_MAIN_EVENT_TYPE_CHANGETEAMID = 1095,
        ITMG_MAIN_EVENT_TYPE_RECONNECT_START = 11,
        ITMG_MAIN_EVENT_TYPE_RECONNECT_SUCCESS = 12,
    } ;

    /// <summary>
    /// The type of callback event for GME room management
    /// </summary>
    public enum ITMG_MAIN_EVNET_TYPE_ROOM_MANAGEMENT_OPERATOR {
        /// <summary>
        /// Capture device event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_CAPTURE_OP = 0,
        /// <summary>
        /// Playback device event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_PLAY_OP = 1,
        /// <summary>
        /// Sending audio event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_AUDIO_SEND_OP = 2,
        /// <summary>
        /// Receiving audio event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_AUDIO_REC_OP = 3,
        /// <summary>
        /// Mic event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_MIC_OP = 4,
        /// <summary>
        /// Speaker event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_SPEAKER_OP = 5,
        /// <summary>
        /// Mic status event for room management
        /// </summary>
        ITMG_ROOM_MANAGEMENT_GET_MIC_STATE = 6,
        /// <summary>
        /// Speaker status event for room managment
        /// </summary>
        ITMG_ROOM_MANAGEMENT_GET_SPEAKER_STATE = 7,
        /// <summary>
        /// Disabling mic and speaker event for room management
        /// </summary>
        ITMG_ROOM_MANAGERMENT_FOBIN_OP = 8,
    } ;

    public enum ITMG_AUDIO_MEMBER_ROLE{
        ITMG_AUDIO_MEMBER_ROLE_ANCHOR = 0,
        ITMG_AUDIO_MEMBER_ROLE_AUDIENCE = 1,
    } ;

    public enum ITMGRangeAudioMode
    {
	    ITMG_RANGE_AUDIO_MODE_WORLD = 0,
	    ITMG_RANGE_AUDIO_MODE_TEAM = 1,
		ITMG_RANGE_AUDIO_MODE_SND_TEAM_REC_TEAM = 100,
	    ITMG_RANGE_AUDIO_MODE_SND_TEAM_REC_PROX = 101,
	    ITMG_RANGE_AUDIO_MODE_SND_TEAM_REC_BOTH = 102,
	    ITMG_RANGE_AUDIO_MODE_SND_PROX_REC_TEAM = 103,
	    ITMG_RANGE_AUDIO_MODE_SND_PROX_REC_PROX = 104,
	    ITMG_RANGE_AUDIO_MODE_SND_PROX_REC_BOTH = 105,
    } ;

	public enum ITMG_RECORD_PERMISSION{
		ITMG_PERMISSION_GRANTED = 0 ,
		ITMG_PERMISSION_Denied = 1,
		ITMG_PERMISSION_NotDetermined = 2 ,
		ITMG_PERMISSION_ERROR = 3,
	};

    public enum ITMG_CHECK_MIC_STATUS{
        ITMG_CHECK_MIC_STATUS_MIC_AVAILABLE = 0,//Microphone available
        ITMG_CHECK_MIC_STATUS_ERROR_FUNC = 1,//Interface-called error
        ITMG_CHECK_MIC_STATUS_NO_GRANTED = 2,//Mic unauthorized 
        ITMG_CHECK_MIC_STATUS_INVALID_MIC = 3,//Microphone unavailable
        ITMG_CHECK_MIC_STATUS_JNI_ERROR = 4,//JNI-called error
        ITMG_CHECK_MIC_STATUS_NOT_INIT = 5,//SDK uninitialized
    };

    public enum  ITMG_CUSTOMDATA_SUB_EVENT{
        ITMG_CUSTOMDATA_AV_SUB_EVENT_UPDATE = 0,
    };
    
    public enum ITMG_SERVER_AUDIO_ROUTE_SEND_TYPE {
        /// <summary>
        ///  Inquire error, please check whether you have entered room and whether the SDK has been initialized
        /// </summary>
        AUDIO_ROUTE_SEND_INQUIRE_ERROR = 0,
        /// <summary>
        /// The local audio is sent to the backend server,but the server doesn't route it to others
        /// which equals to muting yourself.
        /// </summary>
        AUDIO_ROUTE_NOT_SEND_TO_ANYONE = 1,
        /// <summary>
        /// The local audio is sent to everyone 
        /// </summary>
        AUDIO_ROUTE_SEND_TO_ALL = 2,
        /// <summary>
        /// The local audio is not sent to the people in the blacklist 
        /// </summary>
        AUDIO_ROUTE_SEND_BLACK_LIST = 3,
        /// <summary>
        /// The local audio is sent to the people in the whitelist only
        /// </summary>
        AUDIO_ROUTE_SEND_WHITE_LIST = 4,
    };

    public enum ITMG_SERVER_AUDIO_ROUTE_RECV_TYPE {
        /// <summary>
        ///Inquire error,please check whether you have entered room and whether the SDK has been initialized
        /// </summary>
        AUDIO_ROUTE_RECV_INQUIRE_ERROR = 0,
        /// <summary>
        /// The local end does not accept any audios, 
        /// which is equivalent to disabling the speaker
        /// </summary>
        AUDIO_ROUTE_NOT_RECV_FROM_ANYONE = 1,
        /// <summary>
        /// The local end receives everyone's audios
        /// </summary>
        AUDIO_ROUTE_RECV_FROM_ALL = 2,
        /// <summary>
        /// The local end does not receive the audios from the people in the blacklist
        /// </summary>
        AUDIO_ROUTE_RECV_BLACK_LIST = 3,
        /// <summary>
        /// The local end receives audios from the people in the whitelist only
        /// </summary>
        AUDIO_ROUTE_RECV_WHITE_LIST = 4,
    }

    public enum ITMG_USER_AGE_DETECTED_RESULT
    {
        AV_ERR_AGE_DETECTED_SUCCESS_USER_CHILD = 730000,
        AV_ERR_AGE_DETECTED_SUCCESS_USER_ADULT = 730001,
        AV_ERR_AGE_DETECTED_SUCCESS_USER_TEENAGER = 730002,
        AV_ERR_AGE_DETECTED_INTERNAL_ERROR = 730003,
        AV_ERR_AGE_DETECTED_USER_SILENCE = 730004
    }

    public abstract class ITMGContext
	{
        //If the compiler displays a message indicating that GMESDK_VERSION_xxx cannot be found, 
        //it indicates that not all files are upgraded during SDK upgrade.Please upgrade in full
        public static string IENGINE_VERSION = QAVError.GMESDK_VERSION_2_9_5_83c5106c;
        static ITMGContext(){         
            QAVSDKInit.InitSDK();
			QAVContext.GetInstance();
        }
		public static ITMGContext GetInstance()
        {          
			return QAVContext.GetInstance();
		}
        
        public abstract int Poll();
        public abstract int Pause();
        public abstract int Resume();

        /// <summary>
        /// Obtain the SDK version for App data reporting
        /// </summary>
        /// <returns></returns>
        public abstract string GetSDKVersion();

        /// <summary>
        /// Set the App version for SDK data reporting
        /// </summary>
        /// <param name="sAppVersion">App version</param>
        public abstract void SetAppVersion(string sAppVersion);

        /// <summary>
        /// Set the areas that the SDK can serve
        /// </summary>
        /// <param name="region">See the documentation for the service area abbreviation</param>
        public abstract void SetRegion(string region);
        public abstract void SetHost(string chatHost,string pttHost);
        public static int LOG_LEVEL_NONE = -1;   //Do not print the log
        public static int LOG_LEVEL_ERROR = 1;  //Used for critical log
        public static int LOG_LEVEL_INFO = 2; //Used to prompt for information
        public static int LOG_LEVEL_DEBUG = 3; //For development and debugging
        public static int LOG_LEVEL_VERBOSE = 4; //For high-frequency printing information

        public abstract int SetLogLevel(int levelWrite, int levelPrint);
        public abstract int SetLogPath(string logDir);


        /// <summary>
        /// Initialize the SDK
        /// </summary>
        /// <param name="sdkAppID">Unique identifier of an App which comes from Tencent cloud console</param>
        /// <param name="openID">Unique identifier of the local user. The value is in type of INT64.The rules are set by App developers themselves, and currently openID only supports the type of INT64</param>
        /// <returns>See QAVError. If it is already in the room, it will fail</returns>
        public abstract int Init(string sdkAppID, string openID);

        /// <summary>
        /// Uninitialize
        /// </summary>
        /// <returns>See QAVError. If it is already in the room, it will fail</returns>
        public abstract int Uninit();

		public abstract bool IsRoomEntered();
        // When the return value is AV_OK,  the room status is returned by the asynchronous callback OnEnterRoomComplete/ExitRoomComplete 
        // When the return value is not AV_OK, it means the execution fails and there is no asynchronous callback.
        public abstract int EnterRoom(string roomID, ITMGRoomType roomType, byte[] authBuffer);
		public abstract int ExitRoom();
		public abstract int SetAdvanceParams(string KeyCode,string value);
        public abstract string GetAdvanceParams(string KeyCode);

        public abstract int StartRealTimeASR();
        public abstract int StartRealTimeASR(string language);
        public abstract int StopRealTimeASR();

        public abstract int InitAgeDectection(string strBinaryPath, string strParamPath);

        public abstract int EnableAgeDectection(bool bEnable);

        public abstract ITMGRoom GetRoom();
		public abstract ITMGAudioCtrl GetAudioCtrl();
        public abstract ITMGAudioEffectCtrl GetAudioEffectCtrl();
        public abstract ITMGRoomManager GetRoomManager();

		public abstract ITMG_RECORD_PERMISSION CheckMicPermission();

		public abstract ITMGPTT GetPttCtrl();
		
		public abstract event QAVEnterRoomComplete OnEnterRoomCompleteEvent;
		public abstract event QAVExitRoomComplete OnExitRoomCompleteEvent;
		public abstract event QAVRoomDisconnect OnRoomDisconnectEvent;
		public abstract event QAVEndpointsUpdateInfo OnEndpointsUpdateInfoEvent;         // Member status have changed.EventID is showed in the EVENT_ID_ENDPOINT_XXX
        public abstract event QAVOnRoomTypeChangedEvent OnRoomTypeChangedEvent;              //This callback will be called when the room type is changed.
        public abstract event QAVAudioReadyCallback OnAudioReadyEvent;
        public abstract event QAVRoomChangeQualityCallback OnRoomChangeQualityEvent;
        public abstract event QAVCommonEventCallback OnCommonEventCallback;
		public abstract event QAVOnEventCallBack onEventCallBack;

        public static int EVENT_ID_ENDPOINT_ENTER = 1;  // Event of a member entering a room
        public static int EVENT_ID_ENDPOINT_EXIT = 2;   // Event of a member exiting a room
        public static int EVENT_ID_ENDPOINT_HAS_CAMERA_VIDEO = 3;   // Event of a member sending camera video
        public static int EVENT_ID_ENDPOINT_NO_CAMERA_VIDEO = 4;        // Event of a member stopping sending camera video
        public static int EVENT_ID_ENDPOINT_HAS_AUDIO = 5;  // Event of member audio reveived
        public static int EVENT_ID_ENDPOINT_NO_AUDIO = 6;   // Event of audios are not received for 2 consecutive seconds



        //////////////////////////////////////////////////////////////////////////
        // Advanced API, don't use these unless you have consulted the GME team
        public abstract int SetRecvMixStreamCount(int nCount);
        public abstract int SetRangeAudioMode(ITMGRangeAudioMode gameAudioMode);
        public abstract int SetRangeAudioTeamID(int teamID);
        public abstract int SetAudioRole(ITMG_AUDIO_MEMBER_ROLE role);
        public abstract ITMG_CHECK_MIC_STATUS CheckMic();
        
        /// <summary>
        /// 认证 FaceTracker
        /// </summary>
        /// <param name="license">授权文件全路径</param>
        /// <param name="secretKey">授权文件密钥</param>
        /// <returns>0成功，非0失败</returns>
        public abstract int InitFaceTracker(string license, string secretKey);

        /// <summary>
        /// 创建 面部识别器
        /// </summary>
        /// <param name="modelDirPath">模型文件夹全路径</param>
        /// <param name="configFileName">配置文件名</param>
        /// <returns>0成功，非0失败</returns>
        public abstract ITMGFaceTracker CreateFaceTracker(string modelDirPath, string configFileName);
        
        /// <summary>
        /// 创建 面部渲染器
        /// </summary>
        /// <param name="modelAssetPath">模型文件夹全路径</param>
        /// <param name="configFileName">配置文件名</param>
        /// <returns></returns>
        public abstract ITMGFaceRenderer CreateFaceRenderer(string modelAssetPath, string configFileName);
        
    }

	public abstract class ITMGRoom
	{
        public abstract event QAVCustomStreamDataCallback OnCustomStreamDataComplete;
        
        /// <summary>
        ///Get real-time quality information.This function is only for checking quality purpose and is not an necessary API for the game.
        /// </summary>
        /// <returns>Return real-time quality parameters in string format</returns>
        public abstract string GetQualityTips();

        /// <summary>Set the room Type </summary>
        /// <returns>OK indicates success.ERR_FAIL indicates failure, possibly because the room does not exist</returns>
        /// <remarks>For more information about the introduction about roomType, please refer to GME official website </remarks>
        public abstract int ChangeRoomType(ITMGRoomType roomType);

        /// <summary>
        /// When ChangeRoomType (RoomType RoomType) Function is called, the result is returned through this asynchronous callback function.
        /// OK is returned when room type is changed successfully.
        /// </summary>
        public abstract event QAVCallback OnChangeRoomtypeCallback;

        /// <summary> Get room Room type </summary>
        public abstract int GetRoomType();

        /// <summary>
        /// Obtain the local real-time voice room ID
        /// </summary>
        /// <returns>Room ID</returns>
        public abstract string GetRoomID();

        // range : if Spatializer is enabled or WorldMode is selected:
        //		user can't hear the speaker if the distance between them is larger than the range;
        //		by default, range = 0. which means without calling UpdateAudioRecvRange no audio would be available.
        public abstract int UpdateAudioRecvRange(int range);
        // Tell Self's position and rotation information to GME for function: Spatializer && WorldMode
        // position and rotate should be under the world coordinate system specified by forward, rightward, upward direction.
        // for example: in Unreal(forward->X, rightward->Y, upward->Z); in Unity(forward->Z, rightward->X, upward->Y)
        // position: self's position
        // axisForward: the forward axis of self's camera rotation
        // axisRightward: the rightward axis of self's camera rotation
        // axisUpward: the upward axis of self's camera rotation
        public abstract int UpdateSelfPosition(int[] position, float[] axisForward, float[] axisRight, float[] axisUp);
        public abstract int UpdateOtherPosition(string openID, int[] position);

        /// <summary>
        /// Cross-room chat functionality
        /// </summary>
        /// <param name="targetRoomID">Target Room ID of the player you want to chat</param>
        /// <param name="targetOpenID">Target Open ID of the player you want to chat</param>
        /// <param name="authBuffer">Reserved value, please set to NULL(byte[] authBuffer = NULL)</param>
        /// <returns></returns>
        public abstract int StartRoomSharing(string targetRoomID, string targetOpenID, byte[] authBuffer);

        /// <summary>
        /// Stop cross-room chat
        /// </summary>
        /// <returns></returns>
        public abstract int StopRoomSharing();

        // RoomID : the room you want to switch to
        // AuthBuffer : authentication code in Tencent Cloud
        public abstract int SwitchRoom(string roomID, byte[] authBuffer);

        public abstract int SendCustomData(byte[] customdata,int repeatCout);

        public abstract int StopSendCustomData();

        /// <summary>
        /// Set audio route inteface
        /// </summary>
        /// <param name="Sendtype">Sending audio type</param>
        /// <param name="OpenIDforSend">OpenID of the players that you want to send to</param>
        /// <param name="Recvtype">Receiving audio type</param>
        /// <param name="OpenIDforRecv">OpenID of players that you want to receive from</param>
        /// <returns></returns>
        public abstract int SetServerAudioRouteSendOperateType(ITMG_SERVER_AUDIO_ROUTE_SEND_TYPE Sendtype, string[] OpenIDforSend, ITMG_SERVER_AUDIO_ROUTE_RECV_TYPE Recvtype, string[] OpenIDforRecv);

        /// <summary>
        /// Get sending audio type
        /// </summary>
        /// <param name="OpenIDforSend"></param>
        /// <returns></returns>
        public abstract ITMG_SERVER_AUDIO_ROUTE_SEND_TYPE GetCurrentSendAudioRoute(List<string> OpenIDforSend);

        /// <summary>
        /// Get receiving audio type
        /// </summary>
        /// <param name="OpenIDforRecve"></param>
        /// <returns></returns>
        public abstract ITMG_SERVER_AUDIO_ROUTE_RECV_TYPE GetCurrentRecvAudioRoute(List<string> OpenIDforRecve);

        
        public abstract int SendCustomStreamData(byte[] customStreamData);
        
        public abstract int SetCustomStreamDataCallback(IntPtr userData);
    }

    public abstract class ITMGAudioCtrl
	{

        /// <summary>
        /// The recommended way to the enable/disable microphone:EnableMic(value) equals to EnableAudioCaptureDevice(value) + EnableAudioSend(value)
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int EnableMic(bool isEnabled);

        /// <summary>
        /// Just a shortcut。GetMicState() equals to the following operation:IsAudioSendEnabled() && IsAudioCaptureDeviceEnabled()
        /// </summary>
        /// <returns> [0 is off; 1 is on]</returns>
        public abstract int GetMicState();

        /// <summary>
        /// The recommended way to enable/disable speaker. EnableSpeaker(value) equals to the following operation: EnableAudioPlayDevice(value) + EnableAudioRecv(value)
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int EnableSpeaker(bool isEnabled);

        /// <summary>
        /// Just a shortcut.GetSpeakerState() equals to the following operation: IsAudioRecvEnabled() && IsAudioPlayDeviceEnabled()
        /// </summary>
        /// <returns> [0 is off; 1 is on]</returns>
        public abstract int GetSpeakerState();

        /// <summary>
        /// Check the mute button status of iPhone which is only valid for iOS
        /// </summary>
        /// <returns> The returned value is not the mute button status. Please get the status from the callback function.</returns>
        public abstract int CheckDeviceMuteState();

        /// <summary>
        /// Enable capture device and playback device. The devices are disabled by default.
        /// Note: This API can only be called after entering the room, the device will be automatically shut down after exiting room
        /// Note: On mobile devices, enabling the capture device is usually accompanied by permission application, volume type adjustment and other operations.
        /// 
        /// Example scenario:
        /// 1 When the user click the on/off button of the microphone or the speaker，it is adviced to follow these option：
        /// 	Option 1: For most of the game scenarios, you should always call EnableAudioCaptureDevice/EnableAudioSend and EnableAudioPlayDevice/EnableAudioRecv at the same time
        ///		Option 2: For certain social applications: call EnableAudioCapture/PlayDevice(true) ont time after the room is entered. Then control the on/off by just using the EnableAudioSend and EnableAudioRecv.
        ///	2 If two modules or functions have to use the microphone and speaker at the same time, and you need to release the recording permission to other modules temporarily, PauseAudio/ResumeAudio is recommended in this scenario
        /// 
        /// </summary>
        public abstract int EnableAudioCaptureDevice (bool enabled);
		public abstract int EnableAudioPlayDevice (bool enabled);

        /// <summary>
        /// Get if capture device is enabled or not
        /// </summary>
        public abstract bool IsAudioCaptureDeviceEnabled();
        /// <summary>
        /// Get if capture device is enabled or not
        /// </summary>
        public abstract bool IsAudioPlayDeviceEnabled();

        /// <summary>
        /// Enable/disable sending the local audio.If capture device is enabled, the local audio will be sent to the server
        /// If the acquisition device is disabled, it is still silent。Please reference to EnableAudioCaptureDevice.
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int EnableAudioSend(bool isEnabled);

        /// <summary>
        /// Enable/disabel receiving the audio from the server.
        /// 
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int EnableAudioRecv(bool isEnabled);

        /// <summary>
        /// Get if sending audio is enabled or not.
        /// </summary>
        public abstract bool IsAudioSendEnabled();
        /// <summary>
        /// Get if receiving audio is enabled or not.
        /// </summary>
        public abstract bool IsAudioRecvEnabled();

        /// <summary>
        /// Get the real-time input level of microphone
        /// </summary>
        /// <returns>Value range: 0-100</returns>
        public abstract int GetMicLevel();

        /// <summary>
        /// Set the software volume of microphone. The default value is 100 corresponding a zero gain to the volume. Value range: 0-200
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int SetMicVolume(int volume);

        /// <summary>
        /// Get the software volume of microphone.The default value is 100.
        /// </summary>
        /// <returns>return of setMicVolume</returns>
        public abstract int GetMicVolume();

        /// <summary>
        /// Get the real-time output level of the speaker
        /// </summary>
        /// <returns>Value range:0-100</returns>
        public abstract int GetSpeakerLevel();

        /// <summary>
        /// Set the output level of the speaker. The default value is 100 corresponding a zero gain to the volume. Value range:0~200
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int SetSpeakerVolume(int volume);

        /// <summary>
        /// Get the output level of the speaker
        /// </summary>
        /// <returns>return of output level of the speaker</returns>
        public abstract int GetSpeakerVolume();

        /// <summary>
        /// Set the volume of a player specified by the openID
        /// </summary>
        /// <param name="openid">the unique identifier of the player</param>
        /// <param name="volume">Desired volume.Value range:0-200.100 means no zero gain</param>
        /// <returns></returns>
        public abstract int SetSpeakerVolumeByOpenID(string openid, int volume);

        /// <summary>
        /// Get the input level of the speaker by oponID
        /// </summary>
        /// <param name="openid">the unique identifier of the player</param>
        /// <returns></returns>
        public abstract int GetSpeakerVolumeByOpenID(string openid);

        /// <summary>
        /// Get the specified member's volume
        /// </summary>
        /// <returns>return of GetVolumeById</returns>
        public abstract int GetVolumeById(string openid);

        /// <summary>
        /// Enable/disable the loopback
        /// </summary>
        /// <returns>return of GetVolumeById</returns>
        public abstract int EnableLoopBack(bool enable);

		public static int AUDIOROUTE_OTHERS = -1;   //Use another device to play
        public static int AUDIOROUTE_BUILDINRECIEVER = 0;   //Use an earpiece device to play
        public static int AUDIOROUTE_SPEAKER = 1;   //Use a speaker device to play
        public static int AUDIOROUTE_HEADPHONE = 2; //Use a headphone to play
        public static int AUDIOROUTE_BLUETOOTH = 3;     //Use bluetooth device to play

        public abstract event QAVAudioRouteChangeCallback OnAudioRouteChangeComplete;
        public abstract event QAVAudioIOSMuteSwitchResultCallback OnIOSMuteSwitchResult;

        /// <summary>
        /// Blacklist function
        /// </summary>
        /// <param name="openId">List of members whose audio data they do not want to receive</param>
        /// <returns>Return OK on success</returns>
        /// <remarks> Add player with openID to the blacklist. The audio of this player cannnot be heard. </remarks>
        public abstract int AddAudioBlackList(string openId);
        /// <remarks> Remove player with openID from the blacklist. The audio of this player can be heard. </remarks>
        public abstract int RemoveAudioBlackList(string openId);

        /// <summary>
        /// Get the real-time level of the audio to be sent.
        /// </summary>
        /// <returns>The volume value.Value range: 0-100</returns>
        public abstract int GetSendStreamLevel();

        /// <summary>
        /// Get the real-time output level of the player specified by the openID
        /// </summary>
        /// <param name="openId">OpenID of other members in the room</param>
        /// <returns>The volume value.Value range:0~100</returns>
        public abstract int GetRecvStreamLevel(string openId);

		public abstract int InitSpatializer(string modelPath);
        public abstract int EnableSpatializer(bool enable, bool applyTeam);
        public abstract bool IsEnableSpatializer();
        public abstract int SetAudioMixCount(int nCount);

        public abstract int AddSameTeamSpatializer(string openId);

        public abstract int RemoveSameTeamSpatializer(string openId);

        public abstract int AddSpatializerBlacklist(string openId);

        public abstract int RemoveSpatializerBlacklist(string openId);

        public abstract int ClearSpatializerBlacklist();

        public abstract int EnableAudioDispatcher(bool enable);

        public abstract int GetMicListCount();

        public abstract int GetMicList(out List<TMGAudioDeviceInfo> devicesInfo, int count);

        public abstract int SelectMic(string micID);

        public abstract int GetSpeakerListCount();

        public abstract int GetSpeakerList(out List<TMGAudioDeviceInfo> devicesInfo, int count);

        public abstract int SelectSpeaker(string speaker);
    }

	public abstract class ITMGAudioEffectCtrl
	{
        // Callback when playback ends
        public abstract event QAVAccompanyFileCompleteHandler OnAccompanyFileCompleteHandler;
		
		public abstract event QAVFetchVoiceChangerListCallback OnFetchVoiceChangerListCallback;

        // Control interface which can play only one accompaniment at a time
        // loopBack:whether to send mixed messages,which is generally set to true
        // loopCount:number of loops to play, -1 means infinate loops
        public abstract int StartAccompany(string filePath, bool loopBack, int loopCount, int duckerTimeMs);
       	public abstract int StopAccompany(int duckerTimeMs);
		public abstract bool IsAccompanyPlayEnd();
		public abstract int PauseAccompany();
		public abstract int ResumeAccompany();

		public abstract int EnableAccompanyPlay(bool enable);
		public abstract int EnableAccompanyLoopBack(bool enable);
        public abstract int SetAccompanyKey(int nKey);

        // Set the volume of the accompany to be played.It is linear and the default valur is 100.Bigger than 100 means boost and less than 100 means attenuation.
        public abstract int SetAccompanyVolume(int vol);
		public abstract int GetAccompanyVolume();

        // GetAccompanyFileTotalTimeByMs: Get the length of the accompany file.
        // GetAccompanyFileCurrentPlayedTimeByMs: Get the current position of the accompany playback 
        public abstract uint GetAccompanyFileTotalTimeByMs();
		public abstract uint GetAccompanyFileCurrentPlayedTimeByMs();

        public abstract uint GetAccompanyFileTotalTimeByMs(string openId);
        public abstract uint GetAccompanyFileCurrentPlayedTimeByMs(string openId);
        public abstract int SetAccompanyFileCurrentPlayedTimeByMs(uint time);

        // Volume of the sound effect to be played. It is linear and the default is 100. Bigger than 100 means boost and less means attenuation.
        public abstract int GetEffectsVolume();
		public abstract int SetEffectsVolume(int volume);
        public abstract int GetEffectVolume(int soundId);
        public abstract int SetEffectVolume(int soundId, int volume);

        // The control interface, soundId, is managed by the App side and uniquely identifies a single file
        // loop:Whether to loop；
        // pitch:Not implemented.Expected to be unmodified tone and default value is 1.0；
        // pan:Not implemented，Expected to be sound spatial position.
        // It's default value is 0, which indicates that the sound appears straight ahead;-1 means sound effects appear on the left;1 means sound appears on the right
        public abstract int PlayEffect(int soundId, string filePath, bool loop = false, double pitch = 1.0f, double pan = 0.0f, int volume = 100);
		public abstract int PauseEffect(int soundId);
		public abstract int PauseAllEffects();
		public abstract int ResumeEffect(int soundId);
		public abstract int ResumeAllEffects();
		public abstract int StopEffect(int soundId);
		public abstract int StopAllEffects();
		public abstract int EnableEffectSend(int soundId, bool enable);
		public abstract int SetEffectFileCurrentPlayedTimeByMs(int soundId, uint timeMs);

        public abstract int StartRecord(string filePath, int sampleRate, int channels, bool recordLocalMic, bool recordRemote, bool recordAccompany);
        public abstract int StopRecord();
        public abstract int PauseRecord();
        public abstract int ResumeRecord();

        public abstract int EnableRecordLocalMic(bool recordLocalMic);
        public abstract int EnableRecordAccompany(bool recordAccompany);
        public abstract int EnableRecordRemote(bool recordRemote);

        public abstract int InitVoiceChanger(string dataPath);
        public abstract int FetchVoiceChangerList();
        public abstract int SetVoiceChangerName(string voiceName);
        public abstract string GetVoiceChangerParams();
        public abstract float GetVoiceChangerParamValue(string param);
        public abstract int SetVoiceChangerParamValue(string voiceName,float value);

        public static int VOICE_TYPE_ORIGINAL_SOUND = 0;	/// Original sound
		public static int VOICE_TYPE_LOLITA = 1;			/// Girl sound effect
		public static int VOICE_TYPE_UNCLE = 2;				/// Sound effect modelled on uncles
		public static int VOICE_TYPE_INTANGIBLE = 3;		/// Intangible sound effect
		public static int VOICE_TYPE_DEAD_FATBOY = 4;		/// Sound effect modelled on fat nerds
		public static int VOICE_TYPE_HEAVY_MENTAL = 5;	 	/// Sound effect modelled on heavy metal
		public static int VOICE_TYPE_DIALECT = 6;			/// Sound effect modelled on foreigners
		public static int VOICE_TYPE_INFLUENZA = 7;			/// Sound effect modelled on people who catch a cold
		public static int VOICE_TYPE_CAGED_ANIMAL = 8;		/// Sound effect modelled on animals
		public static int VOICE_TYPE_HEAVY_MACHINE = 9;		/// Sound effect modelled on heavy machines
		public static int VOICE_TYPE_STRONG_CURRENT = 10;	/// Sound effect modelled on strong current
		public static int VOICE_TYPE_KINDER_GARTEN = 11;	/// Sound effect modelled on the kindergarten 
		public static int VOICE_TYPE_HUANG = 12;			/// Sound effect modelled on minions
		public abstract int SetVoiceType(int voiceType);
		
		public static int KARAOKE_TYPE_ORIGINAL = 0;
		public static int KARAOKE_TYPE_POP = 1;
		public static int KARAOKE_TYPE_ROCK = 2;
		public static int KARAOKE_TYPE_RB = 3;
		public static int KARAOKE_TYPE_DANCE = 4;
		public static int KARAOKE_TYPE_HEAVEN = 5;
        public static int KARAOKE_TYPE_TTS = 6;
        public abstract int SetKaraokeType(int type);
	}

	public abstract class ITMGPTT
	{
        static ITMGPTT()
        {
            ITMGContext.GetInstance().GetPttCtrl();
        }
		public static ITMGPTT GetInstance()
		{
			return ITMGContext.GetInstance().GetPttCtrl();
		}

		public abstract event QAVRecordFileCompleteCallback OnRecordFileComplete;
		public abstract event QAVUploadFileCompleteCallback OnUploadFileComplete;
		public abstract event QAVDownloadFileCompleteCallback OnDownloadFileComplete;
		public abstract event QAVPlayFileCompleteCallback OnPlayFileComplete;
		public abstract event QAVSpeechToTextCallback OnSpeechToTextComplete;
		public abstract event QAVStreamingRecognitionCallback OnStreamingSpeechComplete;
		public abstract event QAVStreamingRecognitionCallback OnStreamingSpeechisRunning;
        public abstract event QAVDownloadFileWithAuditCompleteCallback OnDownloadFileAuditComplete;
        public abstract event QAVSpeechToTextWithAuditCallback OnSpeechToTextAuditComplete;
        public abstract event QAVSpeechToTextWithTargetTextCallback OnSpeechToTextTargetTextComplete;
        public abstract event QAVTranslateTextCallback OnTranslateTextComplete;
		public abstract event QAVTextToSpeechCallback OnTextToSpeechComplete;


        /// <summary>
        /// Set the PTT authentication buffer
        /// </summary>
        /// <param name="authBuffer">Authentication buffer </param>
        /// <returns> Return OK on success</returns>
        public abstract int ApplyPTTAuthbuffer (byte[] authBuffer);

        /// <summary>
        /// Set the maximal value of the message
        /// </summary>
        /// <param name="msTime">The maximal value of the message </param>
        /// <returns> Return OK on success</returns>
        public abstract int SetMaxMessageLength(int msTime);

        /// <summary>
        /// Set the target language for PTT voice auditing.Only Chinese is supported currently.
        /// If the PTT voice auditing function is not invoked, Chinese is used by default.
        /// </summary>
        /// <param name="sourceLanguage">sourceLanguage for ptt</param>
        /// <returns> Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int SetPTTSourceLanguage(string sourceLanguage);

        /// <summary>
        /// Start recording ptt message.
        /// </summary>
        /// <param name="filePath">Path of the voice message to be stored. File path should be like "your_dir/your_file_name" be sure to use "/" not "\"</param>
        /// <returns>Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int StartRecording(string filePath);

        /// <summary>
        /// Stop recording message.
        /// </summary>
        ///<returns>Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int StopRecording();

        /// <summary>
        /// almost same with StopRecording, except for without throwing RecordFileCompleteHandler
        /// </summary>
        /// <returns><c>true</c> Return OK on success;Return errno on failure @see QAVError</returns>
		public abstract int CancelRecording();

        /// <summary>
        /// Upload the voice message file specified by the the file path
        /// </summary>
        /// <param name="filePath">Path of the voice message to be stored. File path should be like: "your_dir/your_file_name" be sure to use "/" not "\"</param>
        /// <returns> Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int UploadRecordedFile(string filePath);

        /// <summary>
        /// Download the voice message specified by the file ID
        /// </summary>
        /// <param name="fileID">file to be download</param>
        /// <param name="downloadFilePath">Path of the voice message file to be downloaded. file path should be such as: "your_dir/your_file_name" be sure to use "/" not "\"</param>
        /// <param name="msTimeout">time for download, it is micro second. value range[5000, 60000]</param>
        /// <returns>if success return OK, failed return other errno @see QAVError</returns>
        public abstract int DownloadRecordedFile(string fileID, string downloadFilePath);

        /// <summary>
        /// Play the voice message file
        /// </summary>
        /// <param name="filePath">voice data to store. file path should be such as: "your_dir/your_file_name" be sure to use "/" not "\"</param>
        /// <returns> Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int PlayRecordedFile(string filePath);

        /// <summary>
        /// Play the voice message file
        /// </summary>
        /// <param name="filePath">Path of the voice message to be played. file path should be such as: "your_dir/your_file_name" be sure to use "/" not "\"</param>
        /// <param name="voiceType">voice change type value from 0-12</param>
        /// <returns> Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int PlayRecordedFile(string filePath,int voiceType);

        /// <summary>
        /// Stop playing the PTT Message file
        /// </summary>
        /// <returns> Return OK on success;Return errno on failure @see QAVError</returns>
        public abstract int StopPlayFile();

        /// <summary>
        /// Recognizes the specified speech file as text
        /// </summary>
        /// <param name="fileID">file to be recognize</param>
        /// <param name="language">a language id indicate which language to be recognize</param>
        /// <returns>  Return OK on success</returns>
        public abstract int SpeechToText(string fileID);



        /// <summary>
        /// Convert voice message specified by the fildID to text
        /// </summary>
        /// <param name="fileID">file to be recognized</param>
        /// <param name="speechLanguage">The language of the voice message to be recognized.</param>
        /// <returns>  Return OK on success</returns>
        public abstract int SpeechToText(string fileID, string speechLanguage);

        /// <summary>
        /// Convert voice message specified by the fildID to text
        /// </summary>
        /// <param name="fileID">file to be recognized</param>
        /// <param name="speechLanguage">The language of the voice message to be recognized.</param>
        /// <param name="translatelanguage">The target language to be translated</param> 
        /// <returns> Return OK on success</returns>
        public abstract int SpeechToText(string fileID, string speechLanguage, string translatelanguage);

        /// <summary>
        /// Get the size of the specified voice file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns> Return OK on success</returns>
        public abstract int GetFileSize(string filePath);

        /// <summary>
        /// Get the duration of the specified voice file(ms)
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns> Return OK on success</returns>
        public abstract int GetVoiceFileDuration(string filePath);

        /// <summary>
        /// Streaming speech to text
        /// </summary>
        /// <param name="filePath">file path</param>
        public abstract int StartRecordingWithStreamingRecognition(string filePath);


        /// <summary>
        /// Streaming speech to text
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Return OK on success</returns>
        public abstract int StartRecordingWithStreamingRecognition(string filePath, string speechLanguage);

        /// <summary>
        /// Streaming speech to text
        /// </summary>
        /// <param name="filePath">file path</param>
        ///  <param name="language">Language of the audio file</param>
        ///    <param name="translatelanguage">Translate the recognition results of audio files into the specified language</param>
        /// <returns>Return OK on success</returns>
        public abstract int StartRecordingWithStreamingRecognition(string filePath, string speechLanguage, string translatelanguage);

        /// <summary>
        /// Text translation
        /// </summary>
        /// <param name="text">Text to be translated</param>
        ///  <param name="sourceLanguage">The language of the text to be translated which can be null</param>
        ///    <param name="translateLanguage">The translated language of the text, which must not be null,
        ///                 Use commas as spacing,such as"cmn-Hans-CN,en-GB"、"cmn-Hans-CN"</param>
        /// <returns> Return OK on success</returns>
        public abstract int TranslateText(string text, string sourceLanguage, string translateLanguage);

        /// <summary>
        /// Get real-time level of microphone
        /// </summary>
        /// <returns>Value range:0-100</returns>
        public abstract int GetMicLevel();

        /// <summary>
        /// Set the microphone software volume.The default value is 100 which means no increase and no decrease.Value range:0-200
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int SetMicVolume(int volume);

        /// <summary>
        /// Returns the microphone software volume，the default value is 100
        /// </summary>
        /// <returns>Return of setMicVolume</returns>
        public abstract int GetMicVolume();

        /// <summary>
        /// Get real-time level of speaker
        /// </summary>
        /// <returns>Value range:0-100</returns>
        public abstract int GetSpeakerLevel();

        /// <summary>
        /// Set the software volume of the speaker.The default value is 100 which means no increase and no decrease.Value range:0-200
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int SetSpeakerVolume(int volume);

        /// <summary>
        /// Set the software volume of the speaker
        /// </summary>
        /// <returns>Return of SetSpeakerVolume</returns>
        public abstract int GetSpeakerVolume();

        /// <summary>
        /// Pause voice message recording. 
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int PauseRecording();

        /// <summary>
        /// Resume voice message recording 
        /// </summary>
        /// <returns>Return OK on success</returns>
        public abstract int ResumeRecording();

        /// <summary>
        /// Text-to-speech
        /// </summary>
        /// <param name="text">The input text. It cannot be NULL and the maximum size is 5000 characters</param>
        /// <param name="voiceName">The voice for the generated speech,it can be empty, for example：“af-ZA-Standard-A”,
        ///                         Support list: https://cloud.google.com/text-to-speech/docs/voices</param>
        /// <param name="languageCode">Language can no be empty.Language list:https://cloud.tencent.com/document/product/607/30282</param>
        /// <param name="speakingRate">Talk-speed.Value range:0.6-1.5</param>
        /// <returns>Return OK on success</returns>
        public abstract int TextToSpeech(string text, string voiceName,
            string languageCode, float speakingRate);
	}

    /// <summary>
    /// GME room management interface
    /// </summary>
    public abstract class ITMGRoomManager
    {
        static ITMGRoomManager()
        {
            ITMGContext.GetInstance().GetRoomManager();
        }
        public static ITMGRoomManager GetInstance()
        {
            return ITMGContext.GetInstance().GetRoomManager();
        }

        /// <summary>
        /// Enable or disable the microphone of the specified user
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int EnableMic(bool enable, string receiverID);

        /// <summary>
        /// Enable or disable the speaker of the specified user
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int EnableSpeaker(bool enable, string receiverID);

        /// <summary>
        /// Enable or disable the capture device of the specified user
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int EnableAudioCaptureDevice(bool enable, string receiverID);

        /// <summary>
        /// Enable or disable the playback device of the specified user
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int EnableAudioPlayDevice(bool enable, string receiverID);

        /// <summary>
        /// Enable or disable sending audio of the specified user
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int EnableAudioSend(bool enable, string receiverID);

        /// <summary>
        /// Enable or disable receive audio from the specified user
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int EnableAudioRecv(bool enable, string receiverID);

        /// <summary>
        /// Disallow or allow a specified user to operate a speaker or microphone
        /// </summary>
        /// <param name="enable">On or off</param>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int ForbidUserOperation(bool enable, string receiverID);

        /// <summary>
        /// Get the microphone status of the specified user
        /// </summary>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int GetMicState(string receiverID);

        /// <summary>
        /// Get the speaker state of the specified user
        /// </summary>
        /// <param name="receiverID">The receiver openId</param>
        /// <returns>Return OK on success</returns>
        public abstract int GetSpeakerState(string receiverID);
    }

    public enum QAVFaceImageType
    {
        TMGFaceImageType_BGR_8UC3 = 0,
        TMGFaceImageType_RGB_8UC3,
        TMGFaceImageType_GRAY_8UC1,
        TMGFaceImageType_DEPTH_16UC1,
        TMGFaceImageType_BGRA_8UC4,
        TMGFaceImageType_RGBA_8UC4,
        TMGFaceImageType_NV21,
        TMGFaceImageType_NV12,
    }

    public enum QAVImageOrientation
    {
	    QAVImageOrientation_0,
	    QAVImageOrientation_90,
	    QAVImageOrientation_180,
	    QAVImageOrientation_270
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct QAVFaceTrackerParam
    {
        public int minFaceSize;
        public int maxFaceSize;
        public int biggerFaceMode;
        public bool nonSquareRect;
        public float threshold;
        public int detectInterval;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct QAVFaceTrackedFace
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        public float[] faceShap;
        public float pitch;
        public float yaw;
        public float roll;
    }

    public abstract class ITMGFaceTracker
    {
	    /// <summary>                       `
	    /// 释放识别句柄
	    /// </summary>
	    /// <returns></returns>
	    public abstract int Destroy();
	    
	    /// <summary>
	    /// 重置识别接口，当对新的视频进行追踪时调用，用于清空追踪内部状态
	    /// </summary>
	    /// <returns></returns>
	    public abstract int Reset();

	    /// <summary>
	    /// 获取参数
	    /// </summary>
	    /// <returns></returns>
	    public abstract QAVFaceTrackerParam GetParam();

	    /// <summary>
	    /// 修改参数
	    /// </summary>
	    /// <param name="param"></param>
	    public abstract void SetParam(QAVFaceTrackerParam param);

	    /// <summary>
	    /// 识别人脸
	    /// </summary>
	    /// <param name="data">图像的二进制数据</param>
	    /// <param name="imageType">图像格式</param>
	    /// <param name="with">图像的宽度</param>
	    /// <param name="height">图像的高度</param>
	    /// <param name="stride">图像的行宽</param>
	    /// <param name="rotate">图像的旋转角度</param>
	    /// <returns>识别到的人脸数据</returns>
	    public abstract QAVFaceTrackedFace[] TrackFace(byte[] data, QAVFaceImageType imageType, int with, int height, int stride, QAVImageOrientation rotate);
    }

    public abstract class ITMGFaceRenderer
    {
	    /// <summary>                      
	    /// 释放渲染句柄                         
	    /// </summary>                     
	    /// <returns></returns>            
	    public abstract int Destroy();

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="dstData"></param>
	    /// <param name="srcData"></param>
	    /// <param name="imageType"></param>
	    /// <param name="with"></param>
	    /// <param name="height"></param>
	    /// <param name="rotate"></param>
	    /// <param name="faces"></param>
	    /// <returns></returns>
	    public abstract int Render(byte[] dstData, byte[] srcData,  QAVFaceImageType imageType, int with, int height, int rotate, QAVFaceTrackedFace[] faces);
    }
}
