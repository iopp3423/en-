package view;

import javax.swing.*;

import Utility.Constants;

import java.awt.*;

public class PrintCalculator extends JFrame{

	
	static public Container frame; // 프레임 

	
	private void frame()
	{
		setSize(Constants.SCREEN_SIZE_WIDTH,Constants.SCREEN_SIZE_HEIGHT);
		setPreferredSize(new Dimension(Constants.SCREEN_SIZE_WIDTH, Constants.SCREEN_SIZE_HEIGHT));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
		
	}
	
	
	public void getCalculator(CalculatorPanel calculatorPanel, TextPanel textPanel)
	{
		frame();
		setLayout(new BorderLayout()); // 프레임  설정하기 
		

		add(textPanel, BorderLayout.NORTH); // 입력패드 
		add(calculatorPanel, BorderLayout.CENTER); // 키패드 
		setVisible(true);
	}
}


