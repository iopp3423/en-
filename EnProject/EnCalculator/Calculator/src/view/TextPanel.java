package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

public class TextPanel extends JPanel
{
	public JLabel inputSpace;
	
	public TextPanel()
	{
		inputSpace = new JLabel("0");
		setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));
		
		JLabel blankSpace = new JLabel("=");
		JButton log = new JButton("버튼");
		JPanel buttonLabel = new JPanel();
		
		
		log.setFont(new Font("맑은 고딕", 0, 10));
		log.setAlignmentX(RIGHT_ALIGNMENT);
		
		blankSpace.setFont(new Font("맑은 고딕", 0, 20));		// 중간 
		blankSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		inputSpace.setFont(new Font("맑은 고딕", 0, 35));  	// 마지
		inputSpace.setAlignmentX(RIGHT_ALIGNMENT);
		
		
		add(log);
		add(blankSpace);
		add(inputSpace);	
	}
}