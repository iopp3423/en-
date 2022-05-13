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
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import javax.swing.JPanel;

import Utility.Constants;


public class CalculatorPanel extends JPanel
{
	private ActionListener listener; // 버튼에 마우스 이벤트 달아줌 
	MouseAdapter formulaMouse;
	MouseAdapter resultMouse;
	MouseAdapter numberMouse;
	
	public CalculatorPanel(ActionListener Listener)
	{	
		
		this.listener = Listener;
		JButton [] button = new JButton[20];
		setLayout(new GridLayout(5,4, 1, 1));		
 
		button[0] = new JButton("CE");
		button[1] = new JButton("C");
		button[2] = new JButton("\u232B"); // 바꿔야
		button[3] = new JButton("÷");
		
		button[4]  = new JButton("7");
		button[5]  = new JButton("8");
		button[6]  = new JButton("9");
		button[7]  = new JButton("x");
		
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
		
		numberMouse = new MouseAdapter() { // 마우스 올릴 때 색상변경 이벤트 
			public void mouseEntered(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        button.setBackground(new Color(177, 202, 214));
		    }

		    public void mouseExited(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        button.setBackground(new Color(243, 249, 252)); 
		    }
		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
		    	button.setBackground(new Color(243, 249, 252));
		    }
		};
		
		resultMouse = new MouseAdapter() { // 마우스 올릴 때 색상변경 이벤트 
			public void mouseEntered(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        button.setBackground(new Color(57, 135, 191));
		    }

		    public void mouseExited(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        button.setBackground(new Color(101, 156, 195));
		    }
		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
		    	button.setBackground(new Color(101, 156, 195));
		    }
		};
		
		formulaMouse = new MouseAdapter() { // 마우스 올릴 때 색상변경 이벤트 
			public void mouseEntered(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        button.setBackground(new Color(190, 208, 219));
		    }

		    public void mouseExited(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        button.setBackground(new Color(220, 237, 246));
		    }
		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
		    	button.setBackground(new Color(220, 237, 246));
		    }
		  
		    
		};
		
		for(int index = 0; index<Constants.CALCULATOR; index++)
		{
			
			button[index].addActionListener(listener); //버튼에마우스 이벤트 달아줌	
			
			button[index].setOpaque(true);
			button[index].setBorderPainted(false);
			
			
			if(index == 3 || index == 7 || index == 11 || index == 15 || index == 0 || index == 1 || index == 2) {// 숫자패드 제외
				//button[index].setBackground(new Color(0xFF00FFFF, true)); //투명도 FF
				button[index].setBackground(new Color(220, 237, 246));
				button[index].addMouseListener(formulaMouse);
			}
			else if(index == 19) { // = 기호 
				button[index].setBackground(new Color(101, 156, 195));
				button[index].addMouseListener(resultMouse);
			}
			else { // 숫자패드
				
				button[index].setBackground(new Color(243, 249, 252)); 
				button[index].addMouseListener(numberMouse);
			}
			
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



