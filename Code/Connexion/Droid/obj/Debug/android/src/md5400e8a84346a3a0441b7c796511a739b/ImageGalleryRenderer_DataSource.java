package md5400e8a84346a3a0441b7c796511a739b;


public class ImageGalleryRenderer_DataSource
	extends android.widget.BaseAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getItem:(I)Ljava/lang/Object;:GetGetItem_IHandler\n" +
			"n_getItemId:(I)J:GetGetItemId_IHandler\n" +
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"n_getCount:()I:GetGetCountHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Labs.Droid.ImageGalleryRenderer+DataSource, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", ImageGalleryRenderer_DataSource.class, __md_methods);
	}


	public ImageGalleryRenderer_DataSource () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ImageGalleryRenderer_DataSource.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Labs.Droid.ImageGalleryRenderer+DataSource, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public ImageGalleryRenderer_DataSource (md5400e8a84346a3a0441b7c796511a739b.ImageGalleryRenderer p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == ImageGalleryRenderer_DataSource.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Labs.Droid.ImageGalleryRenderer+DataSource, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "Xamarin.Forms.Labs.Droid.ImageGalleryRenderer, Xamarin.Forms.Labs.Droid, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public java.lang.Object getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native java.lang.Object n_getItem (int p0);


	public long getItemId (int p0)
	{
		return n_getItemId (p0);
	}

	private native long n_getItemId (int p0);


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();

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
