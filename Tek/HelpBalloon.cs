using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for HelpBalloon.
	/// </summary>
	public class HelpBalloon
	{
		public static bool TeamHelpShown = false;
		public static bool ResearchHelpShown = false;
		public static bool ResearchCostHelpShown = false;
		public static bool ObjectBrowserHelpShown = false;
		public static bool DamageIndexHelpShown = false;
		public static bool OptionsHelpShown = false;
		public static bool QuickDevelHelpShown = false;
		public static bool MeTargetHelpShown = false;
		public static bool ComparisonHelpShown = false;
		public static bool AccuracyHelpShown = false;
		public static bool ObjectLabelHelpShown = false;
		public static bool LaunchSpeedHelpShown = false;

		public HelpBalloon(string text, Icon icon, Control control, bool showCloseButton, BalloonDirection direction, BalloonEffect effect, Color start, Color mid, Color end)
		{
			MyBalloon = CreateBalloon(control.Handle, 0, 0, text, showCloseButton, icon.Handle, (uint)direction, (uint)effect, (uint)start.ToArgb(), (uint)mid.ToArgb(), (uint)end.ToArgb());
		}

		// Constructor to create a CBalloon object
		public HelpBalloon(string text, Icon icon, Control control, bool showCloseButton, BalloonDirection direction, BalloonEffect effect)
		{
			MyBalloon = CreateBalloon(control.Handle, 0, 0, text, showCloseButton, icon.Handle, (uint)direction, (uint)effect, 0, 0, 0);
		}

		~HelpBalloon()
		{ // Crashes!
			try
			{
				DestroyBalloon(MyBalloon);
			}
			catch (Exception)
			{ // Ignore
			}
		}

		public static void ResetBalloons ()
		{
			AccuracyHelpShown = false;
			ComparisonHelpShown = false;
			DamageIndexHelpShown = false;
			MeTargetHelpShown = false;
			ObjectBrowserHelpShown = false;
			ObjectLabelHelpShown = false;
			OptionsHelpShown = false;
			QuickDevelHelpShown = false;
			ResearchCostHelpShown = false;
			ResearchHelpShown = false;
			TeamHelpShown = false;
			LaunchSpeedHelpShown = false;
		}

		public void ShowBalloon()
		{
			ShowBalloon(MyBalloon);
		}

		public void HideBalloon()
		{
			HideBalloon(MyBalloon);
		}

		////////////////////////////////////////////////////////////////
		/// Implementation
		////////////////////////////////////////////////////////////////
		
		/*  C++ declaration:

			// The x&y coordinates of the balloon are relative to the center of the supplied HWND, if one is supplied
			// otherwise, they are absolute screen coordinates
			static __declspec(dllexport) CBalloon *CreateBalloon(HWND pHWnd, INT x, INT y, const char * sText, BOOL showCloseButton = TRUE, HICON hIcon = NULL, UINT nDirection = BALLOON_RIGHT_TOP, UINT nEffect = BALLOON_EFFECT_SOLID, COLORREF crStart = NULL, COLORREF crMid = NULL, COLORREF crEnd = NULL);

			static __declspec(dllexport) void DestroyBalloon(CBalloon *pb);

			__declspec(dllexport) void ShowBalloon();
			__declspec(dllexport) void HideBalloon();
		*/
		[DllImport("HelpBalloon.dll", EntryPoint="?CreateBalloon@CBalloon@@SAPAV1@PAUHWND__@@HHPBDHPAUHICON__@@IIKKK@Z")]
		private static extern IntPtr CreateBalloon(IntPtr pWnd, int x, int y, string text, bool showCloseButton, IntPtr icon, uint direction, uint effect, uint crStart, uint crMid, uint crEnd);

		[DllImport("HelpBalloon.dll", EntryPoint="?DestroyBalloon@CBalloon@@SAXPAV1@@Z")]
		private static extern void DestroyBalloon(IntPtr instance);

		[DllImport("HelpBalloon.dll", EntryPoint="?ShowBalloon@CBalloon@@QAEXXZ", CallingConvention=CallingConvention.ThisCall)]
		private static extern void ShowBalloon(IntPtr instance);

		[DllImport("HelpBalloon.dll", EntryPoint="?HideBalloon@CBalloon@@QAEXXZ", CallingConvention=CallingConvention.ThisCall)]
		private static extern void HideBalloon(IntPtr instance);

		private IntPtr MyBalloon;
	}

	public enum BalloonEffect : ushort
	{
		BALLOON_EFFECT_SOLID = 0,
		BALLOON_EFFECT_HGRADIENT = 1,
		BALLOON_EFFECT_VGRADIENT = 2,
		BALLOON_EFFECT_HCGRADIENT = 3,
		BALLOON_EFFECT_VCGRADIENT = 4,
		BALLOON_EFFECT_3HGRADIENT = 5,
		BALLOON_EFFECT_3VGRADIENT = 6
	}

	public enum BalloonDirection : ushort
	{
		BALLOON_LEFT_TOP = 0,
		BALLOON_RIGHT_TOP = 1,
		BALLOON_LEFT_BOTTOM = 2,
		BALLOON_RIGHT_BOTTOM = 3
	}
}
