using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GoogleMobileAdsScript : MonoBehaviour {

	private BannerView bannerView;

	// Initialize an InterstitialAd.
	private InterstitialAd interstitial;
	public bool ReactivarIntesrstitial;
	public float Contador;


	/////// CONFIGURACION APP //////
	public void Start(){
		this.RequestBanner();
		this.RequestInterstitial ();

		#if UNITY_ANDROID
		string appId = "ca-app-pub-3234379830532666~6671728175";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3234379830532666~6671728175";
		#else
		string appId = "ca-app-pub-3234379830532666~6671728175";
		#endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
	}


	////// BANNER ///////
	private void RequestBanner(){

		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3234379830532666/7794551234";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/2934735716";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
	
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		bannerView.LoadAd(request);

		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleOnAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		bannerView.OnAdLeavingApplication += HandleOnAdLeftApplication;


	}
		public void HandleOnAdLoaded(object sender, EventArgs args){
		MonoBehaviour.print("HandleAdLoaded event received");
		}

		public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args){
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "+ args.Message);
		}

		public void HandleOnAdOpened(object sender, EventArgs args){
		MonoBehaviour.print("HandleAdOpened event received");
		}

		public void HandleOnAdClosed(object sender, EventArgs args){
		MonoBehaviour.print("HandleAdClosed event received");
		}

		public void HandleOnAdLeftApplication(object sender, EventArgs args){
		MonoBehaviour.print("HandleAdLeftApplication event received");
		}


		////// INTERSTITIAL ///////
		private void RequestInterstitial()
		{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3234379830532666/3237294902";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		interstitial = new InterstitialAd(adUnitId);

		// Called when an ad request has successfully loaded.
		interstitial.OnAdLoaded += HandleOnAdLoadedInterstital;
		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoadInterstital;
		// Called when an ad is shown.
		interstitial.OnAdOpening += HandleOnAdOpenedInterstital;
		// Called when the ad is closed.
		interstitial.OnAdClosed += HandleOnAdClosedInterstital;
		// Called when the ad click caused the user to leave the application.
		interstitial.OnAdLeavingApplication += HandleOnAdLeftApplicationInterstital;

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);



		}

		public void HandleOnAdLoadedInterstital(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdLoaded event received");
		}

		public void HandleOnAdFailedToLoadInterstital(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
		+ args.Message);
		}

		public void HandleOnAdOpenedInterstital(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdOpened event received");
		}

		public void HandleOnAdClosedInterstital(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdClosed event received");
		}

		public void HandleOnAdLeftApplicationInterstital(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdLeftApplication event received");
		}

	void Update(){
		if (GameManager.GameOverBool) {
			if (interstitial.IsLoaded()) {
				interstitial.Show();
				GameManager.GameOverBool = false;
				ReactivarIntesrstitial = true;
			}
		}
		if (ReactivarIntesrstitial) {
			Contador += Time.deltaTime;
			if (Contador >= 10) {
				this.RequestInterstitial ();
				Contador = 0;
				ReactivarIntesrstitial = false;
			}
		}
	}

}

