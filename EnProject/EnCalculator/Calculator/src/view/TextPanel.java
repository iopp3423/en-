package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.Image;

import javax.swing.BoxLayout;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

import Utility.Constants;

public class TextPanel extends JPanel
{
	public JLabel inputSpace;
	public JLabel blankSpace;
	
	public TextPanel()
	{
		ImageIcon image = new ImageIcon("/Users/jojunhui/Desktop/시계.png");
		
		inputSpace = new JLabel("0");
		setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));
		
		blankSpace = new JLabel(" ");
		JButton log = new JButton(new ImageIcon(new ImageIcon("/Users/jojunhui/Desktop/시계.png").getImage().getScaledInstance(30, 20, Image.SCALE_SMOOTH)));
		log.setBorderPainted(false); //있어야 색 적용가능 
		log.setFocusPainted(false); //있어야 색 적용가능 
		log.setContentAreaFilled(false); //있어야 색 적용가능 


		log.setFont(new Font("맑은 고딕", Constants.ZERO, Constants.FONT_SIZE));
		log.setAlignmentX(RIGHT_ALIGNMENT);
		
		blankSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, Constants.FONT_SIZE));		// 중간 
		blankSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		inputSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, Constants.SIZE));  	// 마지
		inputSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		
		add(log);
		add(blankSpace);
		add(inputSpace);		
	}
}