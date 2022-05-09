package use;

import java.awt.*;
import javax.swing.*;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemListener;
import java.awt.event.ItemEvent;


public class Screen {
	
	JFrame frame;

	
	public Screen() {
		initialize();
	}
	
	public void initialize()
	{
		frame = new JFrame(); // 프레임 생성 
		frame.setResizable(false); // 창 크기 조절 불가
		//frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
		
		JPanel FirstPanel = new JPanel();
		JPanel SearchPanel = new JPanel();
		JPanel RecordPanel = new JPanel();
		
		frame.getContentPane().add(FirstPanel);
		
		JButton search = new JButton("검색하기");
		JButton record = new JButton("기록보기");		
		JTextField Input = new JTextField(10);
		
		JPanel panel = new JPanel();
		JPanel button = new JPanel();
		
		search.setBounds(300, 123, 100, 40); // 버튼위치
		record.setBounds(60, 123, 100, 40); // 버튼위치 수
		Input.setBounds(90, 123, 259, 40); // 버튼위치 수
		
		FirstPanel.add(search);
		FirstPanel.add(record);
		FirstPanel.add(Input);
		
		FirstPanel.setVisible(true);
		
		
		
		search.addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {

				frame.setVisible(false);
				SearchingImage(); // 검색하기 
				
			}
				
		});
		
		record.addActionListener(new ActionListener(){ // 기록보기 
			public void actionPerformed(ActionEvent e) {

				frame.setVisible(false);
				CheckLog(); // 기록보기 
			}
				
		});
		
		
	
	}

	
	public void SearchingImage() // 검색하기 
	{
		JFrame frame = new JFrame(); // 프레임 생성 
		String[] Choose = {"10", "20","30"};
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JPanel gridOne = new JPanel(new GridLayout(2,5));
		JPanel gridTwo = new JPanel(new GridLayout(4,5));
		JPanel gridThree = new JPanel(new GridLayout(6,5));
		
		JTextField Input = new JTextField(10);
		JComboBox comboBox = new JComboBox(Choose);
		
		String name[] = {"컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1"};
			
		button.add(search);
		button.add(back);
		panel.add(Input);
		panel.add(button);
		panel.add(comboBox);
		
		System.out.println(comboBox.getItemAt(comboBox.getSelectedIndex()));
		
			
		comboBox.addItemListener(new ItemListener() {

			public void itemStateChanged(ItemEvent e) {

				JComboBox cb = (JComboBox) e.getSource(); //콤보박스 알아내기 

				int index = cb.getSelectedIndex();
				System.out.println(index);
			}

		});

		
		
		if(comboBox.getItemAt(comboBox.getSelectedIndex()) == "10")
		{ 	for(int i=0;i<10;i++)
			{
				JButton jb = new JButton(name[i]);
				gridOne.setSize(300, 200);
				gridOne.add(jb);
			}
		}
		if(comboBox.getItemAt(comboBox.getSelectedIndex()) == "20")
		{ 	for(int i=0;i<20;i++)
			{
				JButton jb = new JButton(name[i]);
				gridTwo.setSize(300, 200);
				gridTwo.add(jb);
			}
		}
		if(comboBox.getItemAt(comboBox.getSelectedIndex()) == "30")
		{ 	for(int i=0;i<30;i++)
			{
				JButton jb = new JButton(name[i]);
				gridThree.setSize(300, 200);
				gridThree.add(jb);
			}
		}
		
		panel.add(gridOne);
		frame.add(panel);
		
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				frame.setVisible(false);
				Screen screen = new Screen();
			}
				
		});
		
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
		
		
	}
	
	
	
	public void CheckLog() // 기록보기  
	{	
		JFrame frame = new JFrame(); // 프레임 생성 
		
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JLabel title = new JLabel("로그 기록");
		title.setSize(150, 150);
		//JTextField Input = new JTextField(10);
		
		
		
		button.add(search);
		button.add(back);
		panel.add(title);
		panel.add(button);
		
		frame.add(panel);
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				//frame.setVisible(false);
			}
				
		});
		
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
		
	}
	
	/*
	public void paintComponent(Graphics image)
	{
		image.drawImage(image, 0, 0, null);
	}
	*/
	
	
	
	
	public void AdjustFrame()
	{
	
	}
	
}
