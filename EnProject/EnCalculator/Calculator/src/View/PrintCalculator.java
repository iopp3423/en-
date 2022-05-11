package View;

import Exception.Constants;


import java.awt.Container;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class PrintCalculator extends JFrame{

	
	private Container frame; // 프레임 

	
	public void GetCalculator()
	{
		panel();
		frame();
	}
	
	private void frame()
	{
		setSize(300,500);
		setResizable(false); // 창 크기 조절 불가
		setPreferredSize(new Dimension(300, 500));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
	}
	
	private void panel()
	{
		frame = getContentPane(); // 프레임 컨텐트 얻
		JPanel calculatorPanel = new JPanel(new GridLayout(5,4));
		JButton [] button = new JButton[20];
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
			
			button[index].addMouseListener(new MouseAdapter() // 마우스 클릭 이벤트 넣
			{
			public void mouseClicked(MouseEvent e) {  
				if (e.getClickCount() == 1) {					
					System.out.println("Hellow");
				}
            }
		});
			
			calculatorPanel.add(button[index]); // 버튼 넣
		}
		frame.add(calculatorPanel);
	}
	
	
}
