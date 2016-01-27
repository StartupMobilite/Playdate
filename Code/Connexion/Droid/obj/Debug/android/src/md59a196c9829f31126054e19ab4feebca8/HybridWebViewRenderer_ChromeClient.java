package md59a196c9829f31126054e19ab4feebca8;


public class HybridWebViewRenderer_ChromeClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onJsAlert:(Landroid/webkit/WebView;Ljava/lang/String;Ljava/lang/String;Landroid/webkit/JsResult;)Z:GetOnJsAlert_Landroid_webkit_WebView_Ljava_lang_String_Ljava_lang_String_Landroid_webkit_JsResult_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Labs.Controls.HybridWebViewRenderer+ChromeClient, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", HybridWebViewRenderer_ChromeClient.class, __md_methods);
	}


	public HybridWebViewRenderer_ChromeClient () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_ChromeClient.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Labs.Controls.HybridWebViewRenderer+ChromeClient, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onJsAlert (android.webkit.WebView p0, java.lang.String p1, java.lang.String p2, android.webkit.JsResult p3)
	{
		return n_onJsAlert (p0, p1, p2, p3);
	}

	private native boolean n_onJsAlert (android.webkit.WebView p0, java.lang.String p1, java.lang.String p2, android.webkit.JsResult p3);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
