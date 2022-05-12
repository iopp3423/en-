package View;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;

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
		JPanel panel = new JPanel(new GridLayout(3,1));
		JLabel blankSpace = new JLabel(" ");
		JButton Log = new JButton("★");
		Log.setPreferredSize(new Dimension(10,10));
		
		Log.setFont(new Font("맑은 고딕", 0, 10));
		Log.setHorizontalAlignment(SwingConstants.RIGHT);
		
		blankSpace.setFont(new Font("맑은 고딕", 0, 35));		
		
		inputSpace.setFont(new Font("맑은 고딕", 0, 30));
		inputSpace.setHorizontalAlignment(SwingConstants.RIGHT);
		
		//setBackground(Color.WHITE);
		panel.add(Log);
		panel.add(blankSpace);
		panel.add(inputSpace);
		add(panel);
		
	}
}