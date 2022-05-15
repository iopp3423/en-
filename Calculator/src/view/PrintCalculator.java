package view;

import javax.swing.*;

import Utility.Constants;

import java.awt.*;
import java.awt.event.KeyAdapter;

public class PrintCalculator{

	
	public JFrame frame;
	private JScrollPane scrollPane;
	
	public void frameset()
	{
		frame = new JFrame();
		frame.setSize(Constants.SCREEN_SIZE_WIDTH,Constants.SCREEN_SIZE_HEIGHT);
		frame.setPreferredSize(new Dimension(Constants.SCREEN_SIZE_WIDTH, Constants.SCREEN_SIZE_HEIGHT));	
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치
		frame.setVisible(true);
		frame.setMinimumSize(new Dimension(250, 250));
		
	}
	
	
	public void getCalculator(CalculatorPanel calculatorPanel, TextPanel textPanel, RecordPanel recordPanel, JScrollPane scrollPane)
	{
		frameset();	
		frame.setLayout(new BorderLayout()); // 프레임  설정하기 
		//scrollPane = new JScrollPane(recordPanel);
		frame.add(scrollPane);
		frame.add(textPanel, BorderLayout.NORTH); // 입력패드 	
		frame.add(calculatorPanel, BorderLayout.CENTER); // 키패드 
		frame.setVisible(true);
		
		textPanel.setVisible(true);
		scrollPane.setVisible(false);
		calculatorPanel.setVisible(true);

	}
}


