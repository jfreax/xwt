//
// WebViewBackend.cs
//
// Author:
//       Cody Russell <cody@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Xwt.Backends;
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.WebKit;

using MonoMac.ObjCRuntime;
using Xwt.Drawing;

namespace Xwt.Mac
{
	public class WebViewBackend : ViewBackend<MonoMac.WebKit.WebView, IWebViewEventSink>, IWebViewBackend
	{
		public WebViewBackend ()
		{
		}

		internal WebViewBackend (MacWebView macweb)
		{
			ViewObject = macweb;
		}

		#region IWebViewBackend implementation
		public override void Initialize()
		{
			base.Initialize ();
			ViewObject = new MacWebView ();
		}

		public string Url {
			get { return Widget.MainFrameUrl; }
			set {
				Widget.MainFrameUrl = value;
			}
		}
		#endregion
	}

	class MacWebView : MonoMac.WebKit.WebView, IViewObject
	{
		public ViewBackend Backend { get; set; }

		public NSView View {
			get { return this; }
		}
	}
}
