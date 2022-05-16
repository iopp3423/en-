package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
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
	private int panelCount = Constants.ZERO;
	
	public TextPanel(CalculatorPanel calculatorPanel, JScrollPane scrollPane,PrintCalculator printCalculator, RecordPanel recordPanel)
	{

	
		inputSpace = new JLabel("0");
		blankSpace = new JLabel(" ");
		setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));
		
		logSet = new JButton(new ImageIcon(new ImageIcon("/Users/jojunhui/Desktop/쓰레기통.png").getImage().getScaledInstance(30, 25, Image.SCALE_SMOOTH)));
		JButton log = new JButton(new ImageIcon(new ImageIcon("/Users/jojunhui/Desktop/시계.png").getImage().getScaledInstance(30, 20, Image.SCALE_SMOOTH)));
		
		logSet.setBorderPainted(false); 
		logSet.setFocusPainted(false); 
		logSet.setContentAreaFilled(false); 
		
		log.setBorderPainted(false); 
		log.setFocusPainted(false); 
		log.setContentAreaFilled(false); 
	
		logSet.setFont(new Font("맑은 고딕", Constants.ZERO, Constants.FONT_SIZE));
		logSet.setAlignmentX(RIGHT_ALIGNMENT);

		log.setFont(new Font("맑은 고딕", Constants.ZERO, Constants.FONT_SIZE));
		log.setAlignmentX(RIGHT_ALIGNMENT);
		
		blankSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, Constants.FONT_SIZE));		// 중간 
		blankSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		inputSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, Constants.INPUT_FONT_SIZE));  	// 마지
		inputSpace.setAlignmentX(RIGHT_ALIGNMENT);
		

			
		
		
		log.addActionListener(new ActionListener(){ // 화면 전
			public void actionPerformed(ActionEvent e) {
				if(panelCount % 2 == Constants.ZERO) {
				calculatorPanel.setVisible(false);
				printCalculator.frame.add(scrollPane);
				scrollPane.setVisible(true);
				panelCount++;
				}
				else {
					calculatorPanel.setVisible(true);
					printCalculator.frame.add(calculatorPanel);
					scrollPane.setVisible(false);
					panelCount++;
					System.out.println("\uD83D\uDDD1");
				}
			}
			
		});
		
		
		logSet.addActionListener(new ActionListener(){ // 기록 초기화
			public void actionPerformed(ActionEvent e) {
				
				for(int index=0; index<recordPanel.button.length; index++)
				{
					recordPanel.button[index].setText("");
				}
			}
		});
		
		

		add(logSet);
		add(log);
		add(blankSpace);
		add(inputSpace);	

	}
	
}