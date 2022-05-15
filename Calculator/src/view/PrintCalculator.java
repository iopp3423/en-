package view;

import javax.swing.*;

import Utility.Constants;

import java.awt.*;
import java.awt.event.KeyAdapter;

public class PrintCalculator extends JFrame{

	
	static public Container frame; // 프레임 
	private JScrollPane scrollPane;
	
	private void frame()
	{
		setSize(Constants.SCREEN_SIZE_WIDTH,Constants.SCREEN_SIZE_HEIGHT);
		setPreferredSize(new Dimension(Constants.SCREEN_SIZE_WIDTH, Constants.SCREEN_SIZE_HEIGHT));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
		setMinimumSize(new Dimension(250, 250));
		
	}
	
	
	public void getCalculator(CalculatorPanel calculatorPanel, TextPanel textPanel, RecordPanel recordPanel)
	{
		frame();
		setLayout(new BorderLayout()); // 프레임  설정하기 
		
		scrollPane = new JScrollPane(recordPanel);

		add(textPanel, BorderLayout.NORTH); // 입력패드 
		//add(calculatorPanel, BorderLayout.CENTER); // 키패드 
		add(scrollPane);
		//add(recordPanel, BorderLayout.CENTER);
		setVisible(true);

	}
}


