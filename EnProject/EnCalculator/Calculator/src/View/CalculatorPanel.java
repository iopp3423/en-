package View;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JPanel;

import Exception.Constants;


public class CalculatorPanel extends JPanel
{
	public JButton [] button = new JButton[20];
	public JPanel buttonPanel = new JPanel(new GridLayout(5,4));
	public ActionListener listener; // 버튼에 마우스 이벤트 달아주는 객
	
	public CalculatorPanel(ActionListener Listener)
	{	
		this.listener = Listener;
		//JPanel buttonPanel = new JPanel(new GridLayout(5,4));		
		add(buttonPanel); // 버튼 넣기 
		
	
		button[0] = new JButton("CE");
		button[1] = new JButton("C");
		button[2] = new JButton("←"); // 바꿔야
		button[3] = new JButton("÷");
		
		button[4]  = new JButton("7");
		button[5]  = new JButton("8");
		button[6]  = new JButton("9");
		button[7]  = new JButton("X");
		
		button[8]  = new JButton("4");
		button[9]  = new JButton("5");
		button[10]  = new JButton("6");
		button[11]  = new JButton("-");
		
		button[12]  = new JButton("1");
		button[13]  = new JButton("2");
		button[14]  = new JButton("3");
		button[15] = new JButton("+");
		
		button[16]  = new JButton("±");
		button[17]  = new JButton("0");
		button[18]  = new JButton(".");
		button[19]  = new JButton("=");
		
		for(int index = 0; index<Constants.calculator; index++)
		{
			//button[index].setForeground(Color.green);

			button[index].setPreferredSize(new Dimension(75, 65));
			
			buttonPanel.setBackground(Color.LIGHT_GRAY);
			buttonPanel.add(button[index]);
			button[index].addActionListener(listener);
			
		}
	}
	
	
	

}
