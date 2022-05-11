package View;

import Exception.Constants;


import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.*;
import java.awt.*;

public class PrintCalculator extends JFrame{

	
	private Container frame; // 프레임 
	
	private void frame()
	{
		setSize(300,500);
		setResizable(false); // 창 크기 조절 불가
		setPreferredSize(new Dimension(300, 500));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
	}
	
	
	public void GetCalculator()
	{
		frame();
		frame = getContentPane(); // 프레임 컨텐트 얻기
		frame.setLayout(new BorderLayout()); // 컨텐트  프레임  설정하기 
		
		CalculatorPanel calculator = new CalculatorPanel(); // 버튼 패널 
		textPanel text = new textPanel();
		
		frame.add(calculator, BorderLayout.SOUTH);
		frame.add(text, BorderLayout.EAST);
		setVisible(true);
	}
			
	class textPanel extends JPanel
	{
		public textPanel()
		{
			JPanel panel = new JPanel(new GridLayout(3,1));
			JLabel blankSpace = new JLabel(" ");
			JLabel inputSpace = new JLabel("0");
			
			blankSpace.setFont(new Font("맑은 고딕", 0, 65));
			
			inputSpace.setFont(new Font("맑은 고닥", 0, 30));
			inputSpace.setHorizontalAlignment(SwingConstants.RIGHT);
			
			
			panel.add(blankSpace);
			panel.add(inputSpace);
			add(panel);
			
		}
		
	}
	
	
	
	
	class CalculatorPanel extends JPanel
	{
		public CalculatorPanel()
		{	
			JPanel buttonPanel = new JPanel(new GridLayout(5,4));		
			JButton [] button = new JButton[20];
			add(buttonPanel); // 버튼 넣기 
		
			button[0] = new JButton("CE");
			button[1] = new JButton("C");
			button[2] = new JButton("지우기"); // 바꿔야
			button[3] = new JButton("/");
			
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
			
			button[16]  = new JButton("+-");
			button[17]  = new JButton("0");
			button[18]  = new JButton(".");
			button[19]  = new JButton("=");
			
			for(int index = 0; index<Constants.calculator; index++)
			{
				button[index].setPreferredSize(new Dimension(75, 65));
				buttonPanel.add(button[index]);
				
				
				button[index].addMouseListener(new MouseAdapter() // 마우스 클릭 이벤트 넣
				{
				public void mouseClicked(MouseEvent e) {  
					if (e.getClickCount() == 1) {					
						System.out.println("dd");
					}
	            }
			});
				
				/*
				button[index].addKeyListener(new KeyAdapter() {   // 이거 버튼에다 다는게 아니라 textfield에 다는게 맞을듯?
					public void Keypressed(KeyEvent e) {
						System.out.println("enter");
						if(e.getKeyChar() == 'd')
							{
								System.out.println("enter");
							}
					}
				});
				*/
			}
		}
	}
	
	
	
	
	
	
	/*
	private void panel()
	{
		frame = getContentPane(); // 프레임 컨텐트 얻기 
		frame.setLayout(new BorderLayout());	
		JPanel textPanel = new JPanel(new GridLayout(3,1)); // 입력값 넣는 곳 
		JPanel calculatorPanel = new JPanel(); // 키패드 넣는 곳 
		JPanel buttonPanel = new JPanel(new GridLayout(5,4));
		JTextField Text = new JTextField("ㅇ");
		JLabel Label = new JLabel("dd");
		JPanel panel = new JPanel();
		JButton [] button = new JButton[20];
		
		Label.setHorizontalAlignment(SwingConstants.RIGHT);
		textPanel.add(Label);
		calculatorPanel.add(buttonPanel);
		
		
		frame.add(textPanel, BorderLayout.EAST);
		frame.add(buttonPanel, BorderLayout.SOUTH);
		//frame.add(buttonPanel);
		
		button[0] = new JButton("CE");
		button[1] = new JButton("C");
		button[2] = new JButton("지우기");
		button[3] = new JButton("/");
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
		button[16]  = new JButton("+-");
		button[17]  = new JButton("0");
		button[18]  = new JButton(".");
		button[19]  = new JButton("=");
		
		for(int index = 0; index<Constants.calculator; index++)
		{
			button[index].setPreferredSize(new Dimension(50, 65));
			buttonPanel.add(button[index]); // 버튼 넣기 
			
			button[index].addMouseListener(new MouseAdapter() // 마우스 클릭 이벤트 넣
			{
			public void mouseClicked(MouseEvent e) {  
				if (e.getClickCount() == 1) {					
					System.out.println("dd");
				}
            }
		});
			
			
			button[index].addKeyListener(new KeyAdapter() {   // 이거 버튼에다 다는게 아니라 textfield에 다는게 맞을듯?
				public void Keypressed(KeyEvent e) {
					System.out.println("enter");
					if(e.getKeyChar() == 'd')
						{
							System.out.println("enter");
						}
				}
			});
			
		}
		//Panel.add(textPanel, BorderLayout.NORTH);
		//Panel.add(calculatorPanel, BorderLayout.SOUTH);
		//frame.add(Panel);
		//frame.add(calculatorPanel);
	}
	*/
	
}


