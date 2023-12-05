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

[Component(PropertyGuid = "bcdf2b9277694a40bd959f829cdb1a11ceff1417")]
public class ButtonExit : Component
{
	EngineWindow window = WindowManager.GetWindow(0);
	public int x = 2;
	public int y = 3;
	public int width = 100;
	public int height = 50;
	public int fontSize = 16;
	public string text = "Exit";
	private WidgetButton button = null;

	public void CreateBut()
	{
		Gui gui = Gui.GetCurrent();
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
	public void Action()
	{
		button.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => Engine.Quit());

	}
	private void Init()
	{
		// write here code to be called on component initialization
		CreateBut();
		Action();
	}

	private void Update()
	{
		// write here code to be called before updating each render frame

	}
}