using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unigine;

[Component(PropertyGuid = "5c415a50ae5c6a09b288e3b61a1fc51bb1e060a3")]
public class ManageMenu : Component
{
	public int fontSize = 16;
	Gui gui = Gui.GetCurrent();
	WidgetWindow windowAbout = new WidgetWindow("Avout Team", 100, 100)
	{
		Width = 500,
		Height = 500,
		Moveable = true,
		Sizeable = true
	};

	private void Init()
	{
		// write here code to be called on component initialization

		WidgetMenuBox Menu = new WidgetMenuBox();
		WidgetLabel testTExt = new WidgetLabel();
		WidgetIcon close_icon = new WidgetIcon(gui, "window_close.png");

		void on_close()
		{
			windowAbout.RemoveChild(close_icon);
			gui.RemoveChild(windowAbout);
			windowAbout.DeleteLater();

		}
		Menu.AddItem("Save");
		Menu.AddItem("Load");
		Menu.AddItem("Settings");
		Menu.AddItem("Exit");
		Menu.FontSize = fontSize;
		Menu.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => { if (Menu.CurrentItemText == "Exit") Engine.Quit(); });

		WidgetMenuBox Team = new WidgetMenuBox();
		Team.AddItem("About");
		//windowAbout.AddChild(testTExt);

		Team.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () =>
		{
			if (Team.CurrentItemText == "About" && !Convert.ToBoolean(gui.IsChild(windowAbout)))
			{
				close_icon.SetPosition(10, -24);
				close_icon.AddCallback(Gui.CALLBACK_INDEX.CLICKED, on_close);
				windowAbout.AddChild(close_icon, Gui.ALIGN_OVERLAP | Gui.ALIGN_RIGHT | Gui.ALIGN_TOP);
				gui.AddChild(windowAbout, Gui.ALIGN_OVERLAP);
			}
			else if (Team.CurrentItemText == "About" && Convert.ToBoolean(gui.IsChild(windowAbout))) { gui.RemoveChild(windowAbout); }
		});
		// close_icon.SetPosition(10, -24);
		// close_icon.AddCallback(Gui.CALLBACK_INDEX.CLICKED, on_close);
		// windowAbout.AddChild(close_icon, Gui.ALIGN_OVERLAP | Gui.ALIGN_RIGHT | Gui.ALIGN_TOP);


		Team.AddItem("Manage Team");
		Team.AddItem("Manage Personal");

		Team.FontSize = fontSize;

		WidgetMenuBox Tournaments = new WidgetMenuBox();
		Tournaments.AddItem("Tournaments");
		Tournaments.FontSize = fontSize;

		WidgetMenuBox Media = new WidgetMenuBox();
		Media.AddItem("Message");
		Media.AddItem("Channels");
		Media.FontSize = fontSize;

		WidgetMenuBox Finance = new WidgetMenuBox();
		Finance.AddItem("Finance");
		Finance.FontSize = fontSize;



		WidgetMenuBar topMenu = new WidgetMenuBar(0, 0);
		topMenu.AddItem("Menu");
		topMenu.AddItem("Team");
		topMenu.AddItem("Tournaments");
		topMenu.AddItem("Media");
		topMenu.AddItem("Finance");
		topMenu.FontSize = fontSize;
		topMenu.SetItemMenu(0, Menu);
		topMenu.SetItemMenu(1, Team);
		topMenu.SetItemMenu(2, Tournaments);
		topMenu.SetItemMenu(3, Media);
		topMenu.SetItemMenu(4, Finance);
		gui.AddChild(topMenu, Gui.ALIGN_OVERLAP);
	}

}