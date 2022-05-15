package view;

import javax.swing.*;

import Utility.Constants;

import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.KeyAdapter;

public class PrintCalculator{

	
	public JFrame frame;
	private JScrollPane scrollPane;
	private int smallSize = Constants.ZERO;
	private int bigSize = Constants.ZERO;
	
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
		frame.add(scrollPane,BorderLayout.EAST);
		scrollPane.setVisible(false);
		frame.add(textPanel, BorderLayout.NORTH); // 입력패드 	
		frame.add(calculatorPanel, BorderLayout.CENTER); // 키패드 
		frame.setVisible(true);
		
		frame.addComponentListener(new ComponentAdapter() {  // 화면 수
		    public void componentResized(ComponentEvent e) {

		    	if(frame.getWidth() >= 600 &&  bigSize == Constants.ZERO) {
		    		scrollPane.setVisible(true);
		    		bigSize = Constants.ONE;
		    		System.out.println(bigSize);
		    	}
		    	if(frame.getWidth() < 600 && bigSize == Constants.ONE){
		    		scrollPane.setVisible(false);   		
		    		bigSize = Constants.ZERO;
		    		System.out.println(bigSize);
		    	}		        
		    }
		});

	}
}


