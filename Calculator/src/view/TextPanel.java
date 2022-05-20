package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

import javax.swing.BoxLayout;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.SwingConstants;

import Utility.Constants;

public class TextPanel extends JPanel
{
	public JLabel inputSpace;
	public JLabel blankSpace;
	public JButton logSet;
	public ComponentAdapter Resize;
	private int panelCount = Constants.RESET;
	
	public TextPanel(CalculatorPanel calculatorPanel, JScrollPane scrollPane, PrintCalculator printCalculator, RecordPanel recordPanel)
	{
		JPanel lastRecordPanel = new JPanel(new GridBagLayout());
		GridBagConstraints recordcontent=new GridBagConstraints();
		
		inputSpace = new JLabel("0");
		blankSpace = new JLabel(" ");
		setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));
		
		logSet = new JButton(new ImageIcon(new ImageIcon("/Users/jojunhui/Desktop/쓰레기통.png").getImage().getScaledInstance(35, 30, Image.SCALE_SMOOTH)));
		JButton log = new JButton(new ImageIcon(new ImageIcon("/Users/jojunhui/Desktop/시계.png").getImage().getScaledInstance(35, 35, Image.SCALE_SMOOTH)));
		
		logSet.setBorderPainted(false); 
		logSet.setFocusPainted(false); 
		logSet.setContentAreaFilled(false); 
		
		log.setBorderPainted(false); 
		log.setFocusPainted(false);
		log.setContentAreaFilled(false); 
	
		logSet.setFont(new Font("맑은 고딕", Constants.RESET, Constants.FONT_SIZE));
		logSet.setAlignmentX(RIGHT_ALIGNMENT);

		log.setFont(new Font("맑은 고딕", Constants.RESET, Constants.FONT_SIZE));
		log.setAlignmentX(RIGHT_ALIGNMENT);
		
		blankSpace.setFont(new Font("맑은 고딕",  Constants.RESET, Constants.FONT_SIZE));		// 중간 
		blankSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, Constants.INPUT_FONT_SIZE));  	// 마지
		inputSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		//lastCalculatorPanel.add(scrollPane, content);
		
				
		recordcontent.fill=GridBagConstraints.BOTH; //여백 채우기
		recordcontent.weighty=0.1;// 비율이 0.2:0.1이므로 버튼의 크기는 세로축으로 2배
		recordcontent.weightx=1;
		recordcontent.gridx=0;  
		recordcontent.gridy=0;   //버튼이 두개로 0,0 기준으로 생성
		//lastRecordPanel.add(textPanel, recordcontent);
		recordcontent.weighty=0.2; // 비율이 0.2:0.1이므로 버튼의 크기는 세축으로 1배
		recordcontent.weightx=1;
		recordcontent.gridx=0;  
		recordcontent.gridy=1;   //버튼이 두개로 0,0 기준으로 생성
		lastRecordPanel.add(scrollPane, recordcontent);
		        
			
		
		
		log.addActionListener(new ActionListener(){ // 화면 전
			public void actionPerformed(ActionEvent e) {
				if(panelCount % 2 == Constants.RESET) {
				calculatorPanel.setVisible(false);
				scrollPane.setVisible(true);
				panelCount++;
				}
				else {
					calculatorPanel.setVisible(true);
					scrollPane.setVisible(false);
					printCalculator.frame.add(printCalculator.lastCalculatorPanel);
					panelCount++;
				}
			}
			
		});
		
		
		
		logSet.addActionListener(new ActionListener(){ // 기록 초기화
			public void actionPerformed(ActionEvent e) {
				
				for(int index=0; index<recordPanel.button.length; index++)
				{
					recordPanel.button[index].setText("");
				}
				recordPanel.button[Constants.RESET].setText("아직 기록이 없습니다.");
			}
		});
		
		

		add(logSet);
		add(log);
		add(blankSpace);
		add(inputSpace);	

	}
	
}