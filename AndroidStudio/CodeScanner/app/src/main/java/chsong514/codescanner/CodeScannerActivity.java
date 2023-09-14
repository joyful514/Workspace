package chsong514.codescanner;

import android.app.TabActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TabHost;

import java.util.ArrayList;
import java.util.List;

@SuppressWarnings("deprecation")
public class CodeScannerActivity extends TabActivity implements View.OnClickListener {
    private TabHost tabhost;
    private ArrayList<String> list1;
    private ArrayAdapter<String> adapter1;
    private ArrayList<String> list2;
    private ArrayAdapter<String> adapter2;
    private Button btnReset;
    private Button btnValidation;

    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //从TabActivity上面获取放置Tab的TabHost
        tabhost = getTabHost();
        TabHost.TabSpec tabSpec1 = tabhost
                //创建新标签one
                .newTabSpec("one")
                //设置标签标题
                .setIndicator("扫码")
                //设置该标签的布局内容
                .setContent(R.id.input_layout);
        TabHost.TabSpec tabSpec2 = tabhost
                //创建新标签one
                .newTabSpec("one")
                //设置标签标题
                .setIndicator("匹配")
                //设置该标签的布局内容
                .setContent(R.id.match_layout);
        tabhost.addTab(tabSpec1);
        tabhost.addTab(tabSpec2);

        EditText codeInput1 = findViewById(R.id.code_input1);
        ListView listView1 = findViewById(R.id.code_list1);
        list1 = new ArrayList<String>();
        adapter1 = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, list1);
        listView1.setAdapter(adapter1);
        ;
        codeInput1.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View view, int i, KeyEvent keyEvent) {
                EditText editText=(EditText)view;
                String text=editText.getText().toString();
                if (i == KeyEvent.KEYCODE_ENTER&&!"\n".equals(text)) {
                    addData(list1,editText.getText().toString());
                    adapter1.notifyDataSetChanged();
                    editText.setText(null);
                }
                return false;
            }
        });

        EditText codeInput2 = findViewById(R.id.code_input2);
        ListView listView2 = findViewById(R.id.code_list2);
        list2 = new ArrayList<String>();
        adapter2 = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, list2);
        listView2.setAdapter(adapter2);
        codeInput2.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View view, int i, KeyEvent keyEvent) {
                EditText editText=(EditText)view;
                String text=editText.getText().toString();
                if (i == KeyEvent.KEYCODE_ENTER&&!"\n".equals(text)) {
                    addData(list2,editText.getText().toString());
                    adapter2.notifyDataSetChanged();
                    editText.setText(null);
                }
                return false;
            }
        });
         btnReset = (Button) findViewById(R.id.btn_reset);
         btnReset.setText("重置");
         btnValidation = (Button) findViewById(R.id.btn_validation);
         btnReset.setOnClickListener(this);
         btnValidation.setText("校验");
        tabhost.setOnTabChangedListener(listener);


    }


    public void addData(List<String> list,String code){
        list.add(code);
    }
   
    private TabHost.OnTabChangeListener listener = new TabHost.OnTabChangeListener(){
        @Override
        public void onTabChanged(String arg0) {
            // TODO Auto-generated method stub
            Log.i("TabChange", arg0);
        }
    };

    @Override
    public void onClick(View view) {
        switch (view.getId()){
            case R.id.btn_reset:
                list1.clear();
                list2.clear();
                adapter1.notifyDataSetChanged();
                adapter2.notifyDataSetChanged();
                break;
            case R.id.btn_validation:
                if(list1.size()!=list2.size()) {

                }

        }
    }

}