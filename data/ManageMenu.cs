using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "5c415a50ae5c6a09b288e3b61a1fc51bb1e060a3")]
public class ManageMenu : Component
{
	public int fontSize = 16;
	Gui gui = Gui.GetCurrent();
	private void Init()
	{
		// write here code to be called on component initialization
		WidgetMenuBox Menu = new WidgetMenuBox();
		Menu.AddItem("Menu");
		Menu.FontSize = fontSize;

		WidgetMenuBox Team = new WidgetMenuBox();
		Team.AddItem("Team");
		Team.FontSize = fontSize;

		WidgetMenuBox Tournaments = new WidgetMenuBox();
		Tournaments.AddItem("Tournaments");
		Tournaments.FontSize = fontSize;

		WidgetMenuBox News = new WidgetMenuBox();
		News.AddItem("News");
		News.FontSize = fontSize;

		WidgetMenuBar topMenu = new WidgetMenuBar(0, 0);
		topMenu.AddItem("Menu");
		topMenu.AddItem("Team");
		topMenu.AddItem("Tournaments");
		topMenu.AddItem("News");
		topMenu.FontSize = fontSize;
		topMenu.SetItemMenu(0, Menu);
		topMenu.SetItemMenu(1, Team);
		topMenu.SetItemMenu(2, Tournaments);
		topMenu.SetItemMenu(3, News);
		gui.AddChild(topMenu, Gui.ALIGN_OVERLAP);
	}

	private void Update()
	{
		// write here code to be called before updating each render frame

	}
}