using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "843e884db0d5c9b2240dc12de9c484a491b15d40")]
public class NewGame : Component
{
	public int x = 200;
	public int y = 300;
	public int width = 200;
	public int height = 40;
	public int fontSize = 16;
	public Node chooseTeam = null;
	private void Init()
	{
		// write here code to be called on component initialization
		Gui gui = Gui.GetCurrent();
		WidgetEditLine firstName = new WidgetEditLine();
		WidgetEditLine secondName = new WidgetEditLine();
		WidgetButton enterNameBut = new WidgetButton();

		firstName.Editable = true;
		secondName.Editable = true;

		firstName.SetPosition(x, y);
		firstName.Width = width;
		firstName.Height = height;
		firstName.FontSize = fontSize;

		secondName.SetPosition(x + firstName.Width + 30, y);
		secondName.Width = width;
		secondName.Height = height;
		secondName.FontSize = fontSize;

		enterNameBut = new WidgetButton(gui, "Enter");
		enterNameBut.SetPosition(x + 2 * width + 20, y);
		enterNameBut.Width = width - 100;
		enterNameBut.Height = height;
		enterNameBut.FontSize = fontSize;

		enterNameBut.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => Entered());

		gui.AddChild(enterNameBut, Gui.ALIGN_OVERLAP);
		gui.AddChild(firstName, Gui.ALIGN_OVERLAP);
		gui.AddChild(secondName, Gui.ALIGN_OVERLAP);

		void Entered()
		{
			Global.FirstName = firstName.Text;
			Global.SecondName = secondName.Text;
			Unigine.Console.WriteLine(Global.FirstName);
			Unigine.Console.WriteLine(Global.SecondName);
			gui.RemoveChild(enterNameBut);
			gui.RemoveChild(firstName);
			gui.RemoveChild(secondName);
			chooseTeam.Enabled = true;
		}

	}

	private void Update()
	{
		// write here code to be called before updating each render frame

	}
}