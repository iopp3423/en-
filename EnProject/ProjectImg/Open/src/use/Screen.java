package use;


import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemListener;
import java.awt.event.ItemEvent;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;


public class Screen {
	
	public JFrame frame;

	
	public Screen() {
		initialize();
	}
	
	public void initialize()
	{
		
		frame = new JFrame(); // 프레임 생성

		frame.setSize(840, 840/12*9);
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setPreferredSize(new Dimension(840, 840/12*9));	
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치
		
		
		JPanel FirstPanel = new JPanel();
		JPanel SearchPanel = new JPanel();
		JPanel RecordPanel = new JPanel();
		FirstPanel.setLayout(null);
		SearchPanel.setLayout(null);
		

		frame.getContentPane().add(FirstPanel);	

		
		//FirstPanel.setVisible(false);
		//SearchPanel.setVisible(true);
		
		//frame.getContentPane().add(RecordPanel);		
				
		
		///////////////////////////////////////검색 패널 
		String[] Choose = {"10", "20","30"};
		JButton Secondsearch = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JTextField SecondInput = new JTextField(10);
		JComboBox comboBox = new JComboBox(Choose);
		
		Secondsearch.setBounds(500, 50, 100, 40); // 버튼위치
		back.setBounds(600, 50, 100, 40); // 
		SecondInput.setBounds(200,50, 300, 40); // 버튼위치 수d
		comboBox.setBounds(700,50, 70, 40);
		JPanel gridOne = new JPanel(new GridLayout(2,5));
		JPanel gridTwo = new JPanel(new GridLayout(4,5));
		JPanel gridThree = new JPanel(new GridLayout(6,5));	
		gridOne.setLayout(null);
		gridOne.setLocation(100,100);
		
		
		String name[] = {"컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1"};
			
		

		SearchPanel.add(SecondInput); // 입력창 
		SearchPanel.add(Secondsearch); // 검색버튼 
		SearchPanel.add(back);// 뒤로가기 버튼 
		SearchPanel.add(comboBox);
		SearchPanel.add(gridOne);
		
			
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
				gridOne.setSize(200, 200);
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
				
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				SearchPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(FirstPanel);	
				FirstPanel.setVisible(true);
			}
				
		});
		
		
		JButton Firstsearch = new JButton("검색하기");
		JButton record = new JButton("기록보기");		
		JTextField Input = new JTextField(10);
		
		
		Firstsearch.setBounds(500, 50, 100, 40); // 버튼위치
		record.setBounds(600, 50, 100, 40); // 
		Input.setBounds(200, 50, 300, 40); // 버튼위치 수d
		
		FirstPanel.add(Input);
		FirstPanel.add(Firstsearch);
		FirstPanel.add(record);
		
		
		//SearchPanel.setVisible(true);
		//FirstPanel.setVisible(true);
	
		
		Firstsearch.addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {

				FirstPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(SearchPanel);
				SearchPanel.setVisible(true);
				//System.out.println("Hello world");
			}
				
		});
		
		record.addActionListener(new ActionListener(){ // 기록보기 
			public void actionPerformed(ActionEvent e) {

				FirstPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(RecordPanel);
				RecordPanel.setVisible(true);
			}
				
		});
		
	
	
		///// 기록 보기
		/*
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JLabel title = new JLabel("로그 기록");
		title.setSize(150, 150);
		*/
		//JTextField Input = new JTextField(10);
		
		
		
		//button.add(search);
		//button.add(back);
		//panel.add(title);
		//panel.add(button);
		
		//frame.add(panel);
		
		
		//back.addActionListener(new ActionListener(){
			//public void actionPerformed(ActionEvent e) {
				
				//frame.setVisible(false);
			//}
				
		//});
		
		
	}
	
	/*
	public void paintComponent(Graphics image)
	{
		image.drawImage(image, 0, 0, null);
	}
	
	
	
	*/
	
}
