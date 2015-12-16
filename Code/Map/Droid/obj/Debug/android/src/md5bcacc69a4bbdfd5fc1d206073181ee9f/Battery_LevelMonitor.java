package md5bcacc69a4bbdfd5fc1d206073181ee9f;


public class Battery_LevelMonitor
	extends md5bcacc69a4bbdfd5fc1d206073181ee9f.BroadcastMonitor
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Labs.Battery+LevelMonitor, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", Battery_LevelMonitor.class, __md_methods);
	}


	public Battery_LevelMonitor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Battery_LevelMonitor.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Labs.Battery+LevelMonitor, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
