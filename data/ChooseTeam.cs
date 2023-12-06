using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "ab3c279e8208007f67748b3ef9bee22a32b2ee0d")]
public class ChooseTeam : Component
{
	private void Init()
	{
		Gui gui = Gui.GetCurrent();
        WidgetWindow teamList = new WidgetWindow("Choose the team", 0, 0)
        {
            Width = 500,
            Height = 500
        };
        gui.AddChild(teamList, Gui.ALIGN_OVERLAP);
	}

	private void Update()
	{
		// write here code to be called before updating each render frame

	}
}