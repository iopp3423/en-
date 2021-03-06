package view;

import javax.swing.*;

import Utility.Constants;

import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.KeyAdapter;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

public class PrintCalculator{

	
	public JFrame frame;
	public JPanel lastCalculatorPanel;
	private int size = Constants.RESET;
	private JScrollPane scrollPane;
	
	public void frameset()
	{
		frame = new JFrame("계산기");
		frame.setSize(Constants.SCREEN_SIZE_WIDTH,Constants.SCREEN_SIZE_HEIGHT);
		frame.setPreferredSize(new Dimension(Constants.SCREEN_SIZE_WIDTH, Constants.SCREEN_SIZE_HEIGHT));	
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치
		
		frame.setMinimumSize(new Dimension(250, 350));
		Toolkit toolkit = Toolkit.getDefaultToolkit(); // 계산기 아이콘 변경
		Image img = toolkit.getImage("/Users/jojunhui/Desktop/en/Calculator/src/Image/계산기.png");
	    frame.setIconImage(img);
	}
	
	
	public void openCalculator(CalculatorPanel calculatorPanel, TextPanel textPanel, RecordPanel recordPanel, JScrollPane scrollPane)
	{
		frameset();	
		lastCalculatorPanel = new JPanel(new GridBagLayout()); //텍스트,입력 패널 합치는 패널 
		GridBagConstraints content=new GridBagConstraints(); /// constraint 설
		content.fill=GridBagConstraints.BOTH; //여백 채우기
		content.weighty=1;// 비율
		content.weightx=1;
		content.gridx=Constants.RESET;  
		content.gridy=Constants.RESET;   //버튼이 두개로 0,0 기준으로 생성
		lastCalculatorPanel.add(textPanel, content);
        content.weighty=2; // 비율
        content.weightx=1;
        content.gridx=Constants.RESET;  
		content.gridy=1;   //버튼이 두개로 0,0 기준으로 생성
		lastCalculatorPanel.add(calculatorPanel, content);
		lastCalculatorPanel.add(scrollPane, content);
		scrollPane.setVisible(false);   
        
		frame.setLayout(new BorderLayout()); // 프레임  설정하기 
		frame.add(lastCalculatorPanel, BorderLayout.CENTER); // 키패드 
		frame.setVisible(true);

		
			
		frame.addComponentListener(new ComponentAdapter() {  // 화면 
		    public void componentResized(ComponentEvent e) {

		    	if(frame.getWidth() >= 600 &&  size == Constants.RESET) {
		    		frame.add(scrollPane,BorderLayout.EAST);
					scrollPane.setVisible(true);
		    		size = Constants.ONE;
		
		    	}
		    	if(frame.getWidth() < 600 && size == Constants.ONE){
		    		lastCalculatorPanel.add(scrollPane, content);
		    		scrollPane.setVisible(false);   		
		    		size = Constants.RESET;

		    	}		        
		    }
		});
		
		frame.addWindowListener( new WindowAdapter() { // 키보드 오토포커
		    public void windowOpened( WindowEvent e ){
		    	for(int index = Constants.RESET; index<Constants.CALCULATOR; index++)
		    	{
		    		calculatorPanel.button[index].requestFocus();
		    	}
		    }
		}); 
	}
	
	
}


