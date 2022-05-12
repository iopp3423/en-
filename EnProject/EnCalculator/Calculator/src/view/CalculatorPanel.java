package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import javax.swing.JButton;
import javax.swing.JPanel;

import Utility.Constants;


public class CalculatorPanel extends JPanel
{
	private  ActionListener listener; // 버튼에 마우스 이벤트 달아줌 
	
	public CalculatorPanel(ActionListener Listener)
	{	
		this.listener = Listener;
		JButton [] button = new JButton[20];
		setLayout(new GridLayout(5,4));		
 
		button[0] = new JButton("CE");
		button[1] = new JButton("C");
		button[2] = new JButton("\u232B"); // 바꿔야
		button[3] = new JButton("÷");
		
		button[4]  = new JButton("7");
		button[5]  = new JButton("8");
		button[6]  = new JButton("9");
		button[7]  = new JButton("X");
		
		button[8]   = new JButton("4");
		button[9]   = new JButton("5");
		button[10]  = new JButton("6");
		button[11]  = new JButton("-");
		
		button[12]  = new JButton("1");
		button[13]  = new JButton("2");
		button[14]  = new JButton("3");
		button[15]  = new JButton("+");
		
		button[16]  = new JButton("±");
		button[17]  = new JButton("0");
		button[18]  = new JButton(".");
		button[19]  = new JButton("=");
		
		for(int index = 0; index<Constants.CALCULATOR; index++)
		{

			button[index].addActionListener(listener); //버튼에마우스 이벤트 달아줌		
			add(button[index]);			
			
			/*
			button[index].addKeyListener(new KeyAdapter(){ // 키보드 입력 이벤트
				public void keyPressed(KeyEvent e) {
					char text = (e.getKeyChar());
					System.out.println(text);					
				}
			});
			*/
		}				
	}
}


