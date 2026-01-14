using Foundation;
using StoreKit;
using System;
using ObjCRuntime;

namespace TenjinSDKBindings;

// @interface TenjinSDK : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]

interface TenjinSDK
{
	// +(TenjinSDK *)init:(NSString *)apiToken __attribute__((deprecated("use `initialize`")));
	[Static]
	[Export ("init:")]
	TenjinSDK Init (string apiToken);

	// +(TenjinSDK *)init:(NSString *)apiToken andSharedSecret:(NSString *)secret __attribute__((deprecated("use `initialize`")));
	[Static]
	[Export ("init:andSharedSecret:")]
	TenjinSDK Init (string apiToken, string secret);

	// +(TenjinSDK *)init:(NSString *)apiToken andAppSubversion:(NSNumber *)subversion __attribute__((deprecated("use `initialize`")));
	[Static]
	[Export ("init:andAppSubversion:")]
	TenjinSDK Init (string apiToken, NSNumber subversion);

	// +(TenjinSDK *)init:(NSString *)apiToken andSharedSecret:(NSString *)secret andAppSubversion:(NSNumber *)subversion __attribute__((deprecated("use `initialize`")));
	[Static]
	[Export ("init:andSharedSecret:andAppSubversion:")]
	TenjinSDK Init (string apiToken, string secret, NSNumber subversion);

	// +(TenjinSDK *)initialize:(NSString *)apiToken;
	[Static]
	[Export ("initialize:")]
	TenjinSDK Initialize (string apiToken);

	// +(TenjinSDK *)initialize:(NSString *)apiToken andSharedSecret:(NSString *)secret;
	[Static]
	[Export ("initialize:andSharedSecret:")]
	TenjinSDK Initialize (string apiToken, string secret);

	// +(TenjinSDK *)initialize:(NSString *)apiToken andAppSubversion:(NSNumber *)subversion;
	[Static]
	[Export ("initialize:andAppSubversion:")]
	TenjinSDK Initialize (string apiToken, NSNumber subversion);

	// +(TenjinSDK *)initialize:(NSString *)apiToken andSharedSecret:(NSString *)secret andAppSubversion:(NSNumber *)subversion;
	[Static]
	[Export ("initialize:andSharedSecret:andAppSubversion:")]
	TenjinSDK Initialize (string apiToken, string secret, NSNumber subversion);

	// -(id)initWithToken:(NSString *)apiToken andSharedSecret:(NSString *)secret andAppSubversion:(NSNumber *)subversion andDeferredDeeplink:(NSURL *)url ping:(BOOL)ping __attribute__((objc_designated_initializer));
	[Export ("initWithToken:andSharedSecret:andAppSubversion:andDeferredDeeplink:ping:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string apiToken, string secret, NSNumber subversion, NSUrl url, bool ping);

	// +(TenjinSDK *)getInstance:(NSString *)apiToken;
	[Static]
	[Export ("getInstance:")]
	TenjinSDK GetInstance (string apiToken);

	// +(TenjinSDK *)getInstance:(NSString *)apiToken andSharedSecret:(NSString *)secret;
	[Static]
	[Export ("getInstance:andSharedSecret:")]
	TenjinSDK GetInstance (string apiToken, string secret);

	// +(TenjinSDK *)getInstance:(NSString *)apiToken andAppSubversion:(NSNumber *)subversion;
	[Static]
	[Export ("getInstance:andAppSubversion:")]
	TenjinSDK GetInstance (string apiToken, NSNumber subversion);

	// +(TenjinSDK *)getInstance:(NSString *)apiToken andSharedSecret:(NSString *)secret andAppSubversion:(NSNumber *)subversion;
	[Static]
	[Export ("getInstance:andSharedSecret:andAppSubversion:")]
	TenjinSDK GetInstance (string apiToken, string secret, NSNumber subversion);

	// +(TenjinSDK *)sharedInstanceWithToken:(NSString *)apiToken __attribute__((deprecated("use `init` and `connect`")));
	[Static]
	[Export ("sharedInstanceWithToken:")]
	TenjinSDK SharedInstanceWithToken (string apiToken);

	// +(TenjinSDK *)sharedInstanceWithToken:(NSString *)apiToken andDeferredDeeplink:(NSURL *)url __attribute__((deprecated("use `init` and `connectWithDeferredDeeplink`")));
	[Static]
	[Export ("sharedInstanceWithToken:andDeferredDeeplink:")]
	TenjinSDK SharedInstanceWithToken (string apiToken, NSUrl url);

	// +(TenjinSDK *)sharedInstance;
	[Static]
	[Export ("sharedInstance")]
	TenjinSDK SharedInstance { get; }

	// +(void)connect;
	[Static]
	[Export ("connect")]
	void Connect ();

	// +(void)connectWithDeferredDeeplink:(NSURL *)url;
	[Static]
	[Export ("connectWithDeferredDeeplink:")]
	void ConnectWithDeferredDeeplink (NSUrl url);

	// +(void)sendEventWithName:(NSString *)eventName;
	[Static]
	[Export ("sendEventWithName:")]
	void SendEventWithName (string eventName);

	// +(void)sendEventWithName:(NSString *)eventName andEventValue:(NSString *)eventValue __attribute__((deprecated("use `sendEventWithName: andValue:` instead")));
	[Static]
	[Export ("sendEventWithName:andEventValue:")]
	void SendEventWithName (string eventName, string eventValue);

	// +(void)sendEventWithName:(NSString *)eventName andValue:(NSInteger)eventValue;
	[Static]
	[Export ("sendEventWithName:andValue:")]
	void SendEventWithName (string eventName, nint eventValue);

	// +(void)transaction:(SKPaymentTransaction *)transaction __attribute__((deprecated("")));
	[Static]
	[Export ("transaction:")]
	void Transaction (SKPaymentTransaction transaction);

	// +(void)transaction:(SKPaymentTransaction *)transaction andReceipt:(NSData *)receipt;
	[Static]
	[Export ("transaction:andReceipt:")]
	void Transaction (SKPaymentTransaction transaction, NSData receipt);

	// +(void)transactionWithProductName:(NSString *)productName andCurrencyCode:(NSString *)currencyCode andQuantity:(NSInteger)quantity andUnitPrice:(NSDecimalNumber *)price;
	[Static]
	[Export ("transactionWithProductName:andCurrencyCode:andQuantity:andUnitPrice:")]
	void TransactionWithProductName (string productName, string currencyCode, nint quantity, NSDecimalNumber price);

	// +(void)transactionWithProductName:(NSString *)productName andCurrencyCode:(NSString *)currencyCode andQuantity:(NSInteger)quantity andUnitPrice:(NSDecimalNumber *)price andTransactionId:(NSString *)transactionId andReceipt:(NSData *)receipt;
	[Static]
	[Export ("transactionWithProductName:andCurrencyCode:andQuantity:andUnitPrice:andTransactionId:andReceipt:")]
	void TransactionWithProductName (string productName, string currencyCode, nint quantity, NSDecimalNumber price, string transactionId, NSData receipt);

	// +(void)transactionWithProductName:(NSString *)productName andCurrencyCode:(NSString *)currencyCode andQuantity:(NSInteger)quantity andUnitPrice:(NSDecimalNumber *)price andTransactionId:(NSString *)transactionId andBase64Receipt:(NSString *)receipt;
	[Static]
	[Export ("transactionWithProductName:andCurrencyCode:andQuantity:andUnitPrice:andTransactionId:andBase64Receipt:")]
	void TransactionWithProductName (string productName, string currencyCode, nint quantity, NSDecimalNumber price, string transactionId, string receipt);

	// -(void)registerDeepLinkHandler:(void (^)(NSDictionary *, NSError *))deeplinkHandler;
	[Export ("registerDeepLinkHandler:")]
	void RegisterDeepLinkHandler (Action<NSDictionary, NSError> deeplinkHandler);

	// -(void)handleSubscriptionPurchase:(SKPaymentTransaction *)transaction;
	[Export ("handleSubscriptionPurchase:")]
	void HandleSubscriptionPurchase (SKPaymentTransaction transaction);

	// +(void)optOut;
	[Static]
	[Export ("optOut")]
	void OptOut ();

	// +(void)optIn;
	[Static]
	[Export ("optIn")]
	void OptIn ();

	// +(void)optOutParams:(NSArray *)params;
	[Static]
	[Export ("optOutParams:")]
	void OptOutParams (NSObject[] @params);

	// +(void)optInParams:(NSArray *)params;
	[Static]
	[Export ("optInParams:")]
	void OptInParams (NSObject[] @params);

	// +(_Bool)optInOutUsingCMP;
	[Static]
	[Export ("optInOutUsingCMP")]
	bool OptInOutUsingCMP { get; }

	// +(void)optOutGoogleDMA;
	[Static]
	[Export ("optOutGoogleDMA")]
	void OptOutGoogleDMA ();

	// +(void)optInGoogleDMA;
	[Static]
	[Export ("optInGoogleDMA")]
	void OptInGoogleDMA ();

	// +(void)appendAppSubversion:(NSNumber *)subversion;
	[Static]
	[Export ("appendAppSubversion:")]
	void AppendAppSubversion (NSNumber subversion);

	// +(void)updateSkAdNetworkConversionValue:(int)conversionValue __attribute__((deprecated("use `updatePostbackConversionValue:`")));
	[Static]
	[Export ("updateSkAdNetworkConversionValue:")]
	void UpdateSkAdNetworkConversionValue (int conversionValue);

	// +(void)updateConversionValue:(int)conversionValue __attribute__((deprecated("use `updatePostbackConversionValue:`")));
	[Static]
	[Export ("updateConversionValue:")]
	void UpdateConversionValue (int conversionValue);

	// +(void)updatePostbackConversionValue:(int)conversionValue;
	[Static]
	[Export ("updatePostbackConversionValue:")]
	void UpdatePostbackConversionValue (int conversionValue);

	// +(void)updatePostbackConversionValue:(int)conversionValue coarseValue:(NSString *)coarseValue;
	[Static]
	[Export ("updatePostbackConversionValue:coarseValue:")]
	void UpdatePostbackConversionValue (int conversionValue, string coarseValue);

	// +(void)updatePostbackConversionValue:(int)conversionValue coarseValue:(NSString *)coarseValue lockWindow:(BOOL)lockWindow;
	[Static]
	[Export ("updatePostbackConversionValue:coarseValue:lockWindow:")]
	void UpdatePostbackConversionValue (int conversionValue, string coarseValue, bool lockWindow);

	// +(void)setCustomerUserId:(NSString *)userId;
	[Static]
	[Export ("setCustomerUserId:")]
	void SetCustomerUserId (string userId);

	// +(NSString *)getCustomerUserId;
	[Static]
	[Export ("getCustomerUserId")]
	string CustomerUserId { get; }

	// +(void)setCacheEventSetting:(BOOL)isCacheEventsEnabled;
	[Static]
	[Export ("setCacheEventSetting:")]
	void SetCacheEventSetting (bool isCacheEventsEnabled);

	// +(void)setEncryptRequestsSetting:(BOOL)isEncryptRequestsEnabled;
	[Static]
	[Export ("setEncryptRequestsSetting:")]
	void SetEncryptRequestsSetting (bool isEncryptRequestsEnabled);

	// +(NSString *)getAnalyticsInstallationId;
	[Static]
	[Export ("getAnalyticsInstallationId")]
	string AnalyticsInstallationId { get; }

	// +(TJNUserProfileData *)getUserProfile;
	[Static]
	[Export ("getUserProfile")]
	TJNUserProfileData UserProfile { get; }

	// +(NSDictionary *)getUserProfileAsDictionary;
	[Static]
	[Export ("getUserProfileAsDictionary")]
	NSDictionary UserProfileAsDictionary { get; }

	// +(void)resetUserProfile;
	[Static]
	[Export ("resetUserProfile")]
	void ResetUserProfile ();

	// +(void)verboseLogs;
	[Static]
	[Export ("verboseLogs")]
	void VerboseLogs ();

	// +(void)debugLogs;
	[Static]
	[Export ("debugLogs")]
	void DebugLogs ();

	// +(void)setLogHandler:(void (^)(NSString *))handler;
	[Static]
	[Export ("setLogHandler:")]
	void SetLogHandler (Action<NSString> handler);

	// +(NSString *)sdkVersion;
	[Static]
	[Export ("sdkVersion")]
	string SdkVersion { get; }

	// +(void)setWrapperVersion:(NSString *)wrapperVersion;
	[Static]
	[Export ("setWrapperVersion:")]
	void SetWrapperVersion (string wrapperVersion);

	// +(void)setValue:(NSString *)value forKey:(NSString *)key;
	[Static]
	[Export ("setValue:forKey:")]
	void SetValue (string value, string key);

	// +(void)registerAppForAdNetworkAttribution __attribute__((deprecated("use `updatePostbackConversionValue:`")));
	[Static]
	[Export ("registerAppForAdNetworkAttribution")]
	void RegisterAppForAdNetworkAttribution ();

	// +(void)requestTrackingAuthorizationWithCompletionHandler:(void (^)(NSUInteger))completion;
	[Static]
	[Export ("requestTrackingAuthorizationWithCompletionHandler:")]
	void RequestTrackingAuthorizationWithCompletionHandler (Action<nuint> completion);

	// -(void)getAttributionInfo:(void (^)(NSDictionary *, NSError *))completionHandler;
	[Export ("getAttributionInfo:")]
	void GetAttributionInfo (Action<NSDictionary, NSError> completionHandler);

	// -(void)setGoogleDMAParametersWithAdPersonalization:(BOOL)adPersonalization adUserData:(BOOL)adUserData;
	[Export ("setGoogleDMAParametersWithAdPersonalization:adUserData:")]
	void SetGoogleDMAParametersWithAdPersonalization (bool adPersonalization, bool adUserData);
}


// @interface TJNUserProfileData
[BaseType(typeof(NSObject), Name = "_TtC9TenjinSDK18TJNUserProfileData")]
interface TJNUserProfileData
{
	// @property (readonly, nonatomic) int sessionCount;
	[Export ("sessionCount")]
	int SessionCount { get; }

	// @property (readonly, nonatomic) int totalSessionTime;
	[Export ("totalSessionTime")]
	int TotalSessionTime { get; }

	// @property (readonly, nonatomic) int lastSessionLength;
	[Export ("lastSessionLength")]
	int LastSessionLength { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable currentSessionStartTime;
	[NullAllowed, Export ("currentSessionStartTime", ArgumentSemantic.Copy)]
	NSDate CurrentSessionStartTime { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable lastBackgroundTime;
	[NullAllowed, Export ("lastBackgroundTime", ArgumentSemantic.Copy)]
	NSDate LastBackgroundTime { get; }

	// @property (readonly, nonatomic) int currentSessionPausedTime;
	[Export ("currentSessionPausedTime")]
	int CurrentSessionPausedTime { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable firstSessionDate;
	[NullAllowed, Export ("firstSessionDate", ArgumentSemantic.Copy)]
	NSDate FirstSessionDate { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable lastSessionDate;
	[NullAllowed, Export ("lastSessionDate", ArgumentSemantic.Copy)]
	NSDate LastSessionDate { get; }

	// @property (readonly, nonatomic) int iapTransactionCount;
	[Export ("iapTransactionCount")]
	int IapTransactionCount { get; }

	// @property (readonly, nonatomic) double totalILRDRevenueUSD;
	[Export ("totalILRDRevenueUSD")]
	double TotalILRDRevenueUSD { get; }

	// @property (readonly, nonatomic) int currentSessionDuration;
	[Export ("currentSessionDuration")]
	int CurrentSessionDuration { get; }

	// @property (readonly, nonatomic) int totalSessionTimeIncludingCurrent;
	[Export ("totalSessionTimeIncludingCurrent")]
	int TotalSessionTimeIncludingCurrent { get; }

	// @property (readonly, nonatomic) int averageSessionLength;
	[Export ("averageSessionLength")]
	int AverageSessionLength { get; }

	// -(double)getILRDRevenueForNetwork:(enum TJNAdNetwork)network __attribute__((warn_unused_result("")));
	[Export ("getILRDRevenueForNetwork:")]
	double GetILRDRevenueForNetwork (TJNAdNetwork network);

	// -(double)getIAPRevenueForCurrency:(NSString * _Nonnull)currencyCode __attribute__((warn_unused_result("")));
	[Export ("getIAPRevenueForCurrency:")]
	double GetIAPRevenueForCurrency (string currencyCode);

	// -(id)toDictionary __attribute__((warn_unused_result("")));
	[Export ("toDictionary")]
	NSObject ToDictionary { get; }

	// -(id)toScalarDictionary __attribute__((warn_unused_result("")));
	[Export ("toScalarDictionary")]
	NSObject ToScalarDictionary { get; }
}
