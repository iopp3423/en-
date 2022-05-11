package View;

import Exception.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
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
		
	
}


