using ObjCRuntime;

namespace TenjinSDKBindings;

[Native]
public enum PurposeConsentStatus : long
{
    Null = 0,
    True = 1,
    False = 2
}

[Native]
public enum TJNAdNetwork : long
{
    IronSource = 0,
    AppLovin = 1,
    AdMob = 2,
    HyperBid = 3,
    TopOn = 4,
    Cas = 5,
    TradPlus = 6
}
