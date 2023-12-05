/* Copyright (C) 2005-2023, UNIGINE. All rights reserved.
*
* This file is a part of the UNIGINE 2 SDK.
*
* Your use and / or redistribution of this software in source and / or
* binary form, with or without modification, is subject to: (i) your
* ongoing acceptance of and compliance with the terms and conditions of
* the UNIGINE License Agreement; and (ii) your inclusion of this notice
* in any version of this software that you use or redistribute.
* A copy of the UNIGINE License Agreement is available by contacting
* UNIGINE. at http://unigine.com/
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "1427a6a309ec6179e4c251f3d75d739d5d6d90ec")]
public class ButtonStart : Component
{
	EngineWindow window = WindowManager.GetWindow(0);
	public int x = 200;
	public int y = 300;
	public int width = 100;
	public int height = 50;
	public int fontSize = 16;
	public string text = "Start";
	public Node controlNode = null;
	private WidgetButton button = null;

	Gui gui = Gui.GetCurrent();
	public void CreateBut()
	{
		// create button
		button = new WidgetButton(gui, text);
		button.SetPosition(x, y);
		button.Width = width;
		button.Height = height;
		button.FontSize = fontSize;
		// add button to current gui
		gui.AddChild(button, Gui.ALIGN_OVERLAP);
		Unigine.Console.Onscreen = true;
	}
	public void Act()
	{
		controlNode.Enabled = !controlNode.Enabled;
		Unigine.Console.WriteLine(controlNode.Enabled);
		//controlButton.RemoveChild(button);
		//gui.Destroy();

// 		for (int i = 0; i<=gui.NumChildren; i++){
// 		gui.RemoveChild(gui.GetChild(0));
// 		//if ()
// }
		button.SetPosition(x+1000, y+1000);
		//gui.RemoveChild(button);
		//gui.Update();
	}
	public void Action()
	{

		button.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => Act()
		);

		//Unigine.Console.WriteLine("12")
	}
	private void Init()
	{
		// write here code to be called on component initialization
		CreateBut();
		Action();
	}
}