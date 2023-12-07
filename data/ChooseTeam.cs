using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unigine;

[Component(PropertyGuid = "ab3c279e8208007f67748b3ef9bee22a32b2ee0d")]
public class ChooseTeam : Component
{
	public Node manageMenu = null;

	Gui gui = Gui.GetCurrent();
	WidgetHPaned widgetH = new WidgetHPaned();
	WidgetVBox teamsBox = new WidgetVBox();
	WidgetVBox teamBox = new WidgetVBox();
	WidgetScrollBox scrollTeams = new WidgetScrollBox();
	WidgetListBox teamList = new WidgetListBox();
	WidgetLabel selectedTeam = new WidgetLabel();
	private void Init()
	{



		WidgetWindow windowTeamList = new WidgetWindow("Choose the team", 0, 0)
		{
			Width = 500,
			Height = 500
		};

		scrollTeams.Width = windowTeamList.Width / 3;
		scrollTeams.Height = windowTeamList.Height;
		for (int i = 0; i < Global.teamList.Count(); i++)
		{
			teamList.AddItem(Global.teamList.ElementAt(i).Key);

		}
		// for (int i = 0; i < Global.nickNamesList.Count(); i++)
		// 	nicknames.AddItem(Global.nickNamesList.ElementAt(i));
		//teamList.SetItemData(0,"123");


		WidgetButton enterNameBut = new WidgetButton();
		enterNameBut = new WidgetButton(gui, "Enter");
		//gui.AddChild(enterNameBut, Gui.ALIGN_OVERLAP);

		void chosen()
		{
			Global.ChoosenTeam = teamList.GetCurrentItemText();
			Unigine.Console.WriteLine(Global.ChoosenTeam);
			selectedTeam.Text = $"Team name: {Global.teamList[Global.ChoosenTeam].name}\nTeam power: {Global.teamList[Global.ChoosenTeam].power}\nTeam money: {Global.teamList[Global.ChoosenTeam].money}\nTeam complexity: {Global.teamList[Global.ChoosenTeam].complexity}\n";
		}

		void enter()
		{
			Global.ChoosenTeam = teamList.GetCurrentItemText();
			Unigine.Console.WriteLine(Global.ChoosenTeam);
			manageMenu.Enabled = true;
			gui.RemoveChild(windowTeamList);
			gui.RemoveChild(enterNameBut);
		}

		enterNameBut.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => enter());
		teamList.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => chosen());

		scrollTeams.AddChild(teamList);



		teamsBox.AddChild(scrollTeams);
		teamBox.AddChild(selectedTeam);



		//widgetH.AddChild(scrollTeams);

		//Два Вбокса ни больше ни меньше и именно вбокс
		widgetH.AddChild(teamBox);
		widgetH.AddChild(teamsBox);
		widgetH.SetPosition(500, 0);
		widgetH.Value = 0;

		windowTeamList.AddChild(widgetH);
		windowTeamList.AddChild(enterNameBut);

		gui.AddChild(windowTeamList, Gui.ALIGN_OVERLAP);
	}
}