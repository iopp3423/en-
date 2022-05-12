package view;

import javax.swing.*;

import Utility.Constants;

import java.awt.*;

public class PrintCalculator extends JFrame{

	
	static public Container frame; // 프레임 
	private CalculatorPanel calculator;
	private TextPanel textPanel;
	
	private void frame()
	{
		setSize(300,500);
		setPreferredSize(new Dimension(300, 500));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
	}
	
	
	public void GetCalculator(CalculatorPanel calculatorPanel, TextPanel textPanel )
	{
		frame();
		frame = getContentPane(); // 프레임 컨텐트 얻기
		frame.setLayout(new BorderLayout()); // 컨텐트  프레임  설정하기 
		
		this.textPanel = textPanel; // 입력패드 
		this.calculator = calculatorPanel; // 버튼 + 이벤트 달아주는 객체 
		
		
		frame.add(textPanel, BorderLayout.NORTH); // 입력패드 
		frame.add(calculator, BorderLayout.CENTER); // 키패드 
		
		setVisible(true);
	}	
}


