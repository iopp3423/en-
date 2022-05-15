package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
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
	public ComponentAdapter Resize;
	
	public TextPanel(CalculatorPanel calculatorPanel, JScrollPane scrollPane,PrintCalculator printCalculator)
	{
		ImageIcon image = new ImageIcon("/Users/jojunhui/Desktop/시계.png");
	
		inputSpace = new JLabel("0");
		setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));
		
		blankSpace = new JLabel(" ");
		JButton log = new JButton(new ImageIcon(new ImageIcon("/Users/jojunhui/Desktop/시계.png").getImage().getScaledInstance(30, 20, Image.SCALE_SMOOTH)));
		log.setBorderPainted(false); 
		log.setFocusPainted(false); 
		log.setContentAreaFilled(false); 


		log.setFont(new Font("맑은 고딕", Constants.ZERO, Constants.FONT_SIZE));
		log.setAlignmentX(RIGHT_ALIGNMENT);
		
		blankSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, Constants.FONT_SIZE));		// 중간 
		blankSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		inputSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, Constants.INPUT_FONT_SIZE));  	// 마지
		inputSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		
		log.addActionListener(new ActionListener(){ // 누른 키패드 가져오기
			public void actionPerformed(ActionEvent e) {
				System.out.println("Heelo");
				//recordPanel.removeAll();
				//calculatorPanel.removeAll();
				calculatorPanel.setVisible(false);
				printCalculator.frame.add(scrollPane);
				scrollPane.setVisible(true);
			}
			
		});
		
		add(log);
		add(blankSpace);
		add(inputSpace);	

	}
	
}