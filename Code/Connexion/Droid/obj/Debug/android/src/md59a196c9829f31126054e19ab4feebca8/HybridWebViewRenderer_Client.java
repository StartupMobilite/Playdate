package md59a196c9829f31126054e19ab4feebca8;


public class HybridWebViewRenderer_Client
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_shouldOverrideUrlLoading:(Landroid/webkit/WebView;Ljava/lang/String;)Z:GetShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Labs.Controls.HybridWebViewRenderer+Client, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", HybridWebViewRenderer_Client.class, __md_methods);
	}


	public HybridWebViewRenderer_Client () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_Client.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Labs.Controls.HybridWebViewRenderer+Client, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public HybridWebViewRenderer_Client (md59a196c9829f31126054e19ab4feebca8.HybridWebViewRenderer p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_Client.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Labs.Controls.HybridWebViewRenderer+Client, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "Xamarin.Forms.Labs.Controls.HybridWebViewRenderer, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1)
	{
		return n_shouldOverrideUrlLoading (p0, p1);
	}

	private native boolean n_shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1);

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
