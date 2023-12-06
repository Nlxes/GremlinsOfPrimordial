using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unigine;

[Component(PropertyGuid = "ab3c279e8208007f67748b3ef9bee22a32b2ee0d")]
public class ChooseTeam : Component
{
	private void Init()
	{
		Gui gui = Gui.GetCurrent();

		WidgetHPaned widgetH = new WidgetHPaned();
		WidgetVBox VBteams = new WidgetVBox();
		WidgetVBox team = new WidgetVBox();
		WidgetScrollBox scrollTeams = new WidgetScrollBox();
		WidgetWindow windowTeamList = new WidgetWindow("Choose the team", 0, 0)

		{
			Width = 500,
			Height = 500
		};

		WidgetListBox teamList = new WidgetListBox(gui);
		for (int i =0; i<Global.teamList.Count(); i++)
		teamList.AddItem(Global.teamList.ElementAt(i).Key);
		//teamList.SetItemData(0,"123");
		VBteams.AddChild(teamList);
		VBteams.Width = windowTeamList.Width/2;
		VBteams.Height = windowTeamList.Height;

		scrollTeams.AddChild(VBteams);
		scrollTeams.Width = VBteams.Width;
		scrollTeams.Height = VBteams.Height;
		widgetH.AddChild(team);
		widgetH.AddChild(scrollTeams);
		windowTeamList.AddChild(widgetH);
		gui.AddChild(windowTeamList, Gui.ALIGN_OVERLAP);
	}

	private void Update()
	{
		// write here code to be called before updating each render frame

	}
}