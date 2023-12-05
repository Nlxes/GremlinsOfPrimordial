using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "752838eb6d18b370d0d5de01d286e7dd97f6a679")]
public class Menu : Component
{
	EngineWindow window = WindowManager.GetWindow(0);//чтоб в процентом все делать
	public int x = 200;
	public int y = 300;
	public int width = 100;
	public int height = 50;
	public int fontSize = 16;
	public List<string> buttonsNames = null;
	public Node controlledNode = null;
	private WidgetButton buttonStart = null;
	private WidgetButton buttonContinue = null;
	private WidgetButton buttonExit = null;

	Gui gui = Gui.GetCurrent();

	public void StartNewGame()
	{
		Unigine.Console.WriteLine("ssssss");
		controlledNode.Enabled = true;
		gui.RemoveChild(buttonExit);
		gui.RemoveChild(buttonContinue);
		gui.RemoveChild(buttonStart);
		//Unigine.Console.WriteLine(controlledNode.);

		Unigine.Console.WriteLine(Global.ChoosenTeam);
		Global.nickNamesList.AddRange(Database.nicks);
		PreFight pickStage = new PreFight();
		pickStage.createMeta();
		for (int i = 0; i < 50; i++)
		{
			Team team = new Team(10, 30);
			Global.teamList.Add(team.name, team);
		}
		for (int i = 0; i < 50; i++)
		{
			Team team = new Team(30, 60);
			Global.teamList.Add(team.name, team);
		}
		for (int i = 0; i < 50; i++)
		{
			Team team = new Team(60, 99);
			Global.teamList.Add(team.name, team);
		}
		// WidgetComboBox topMenu = new WidgetComboBox(gui);
		// topMenu.SetPosition(0, 0);
		// topMenu.FontSize = fontSize;

		// // add items
		// topMenu.AddItem("item 0");
		// topMenu.AddItem("item 1");
		// topMenu.AddItem("item 2");

		// topMenu.AddCallback(Gui.CALLBACK_INDEX.CHANGED, () => Unigine.Console.OnscreenMessageLine($"Combobox: {topMenu.GetCurrentItemText()}"));

		// // add combobox to current gui
		// gui.AddChild(topMenu, Gui.ALIGN_OVERLAP);
		WidgetMenuBox Managing = new WidgetMenuBox();
		Managing.AddItem("Managing");
		Managing.FontSize = fontSize;
//		gui.AddChild(Managing, Gui.ALIGN_OVERLAP);

		WidgetMenuBar topMenu = new WidgetMenuBar(0, 0);
		topMenu.AddItem("Managing");
		topMenu.FontSize = fontSize;
		topMenu.SetItemMenu(1,Managing);
		gui.AddChild(topMenu, Gui.ALIGN_OVERLAP);
	}

	public void ContinueGame() { }

	private void Init()
	{
		buttonStart = new WidgetButton(gui, buttonsNames[0]);
		buttonStart.SetPosition(x, y);
		buttonStart.Width = width;
		buttonStart.Height = height;
		buttonStart.FontSize = fontSize;

		buttonContinue = new WidgetButton(gui, buttonsNames[1]);
		buttonContinue.SetPosition(x, y + height);
		buttonContinue.Width = width;
		buttonContinue.Height = height;
		buttonContinue.FontSize = fontSize;

		buttonExit = new WidgetButton(gui, buttonsNames[2]);
		buttonExit.SetPosition(x, y + 2 * height);
		buttonExit.Width = width;
		buttonExit.Height = height;
		buttonExit.FontSize = fontSize;
		// add button to current gui

		gui.AddChild(buttonStart, Gui.ALIGN_OVERLAP);
		gui.AddChild(buttonContinue, Gui.ALIGN_OVERLAP);
		gui.AddChild(buttonExit, Gui.ALIGN_OVERLAP);
		Unigine.Console.Onscreen = true; // чтоб консольне открывать сверху слева врайтлан виден был
		buttonStart.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => StartNewGame());
		buttonContinue.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => ContinueGame());
		buttonExit.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => Engine.Quit());
	}
}