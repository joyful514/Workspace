package com.chsong514;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.chsong514.entity.Question;

public class QuziActivity extends AppCompatActivity {

    private Button mTrueButton;
    private Button mFalseButton;
    private TextView mQuestTextView;
    private int mCurrentIndex=0;
    private Question[] mQuestionBank=new Question[]{
            new Question(R.string.question_australia,true),
            new Question(R.string.question_oceans,true),
            new Question(R.string.question_mideast,false),
            new Question(R.string.question_africa,false),
            new Question(R.string.question_americas,true),
            new Question(R.string.question_asia,true)
    };
    private Button mNextButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mTrueButton=findViewById(R.id.true_button);
        mFalseButton=findViewById(R.id.false_button);
        mQuestTextView=findViewById(R.id.question_text_view);
        mNextButton=findViewById(R.id.next_button);
        updateQuestion();
        mTrueButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                checkAnswer(true);
            }
        });
        mFalseButton.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View view) {
                checkAnswer(false);
            }
        });
        mNextButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mCurrentIndex=(mCurrentIndex+1)%mQuestionBank.length;
                updateQuestion();
            }
        });

    }

    private void checkAnswer(boolean userPressedTrue) {
        boolean answerIsTrue=mQuestionBank[mCurrentIndex].isAnswerTrue();
        if(userPressedTrue==answerIsTrue){
            Toast.makeText(QuziActivity.this, R.string.true_text, Toast.LENGTH_SHORT).show();
        }else{
            Toast.makeText(QuziActivity.this,R.string.false_text,Toast.LENGTH_SHORT).show();
        }
    }

    private void updateQuestion() {
        Question question = mQuestionBank[mCurrentIndex];
        int questionId= question.getTextResId();
        boolean isAnswerTrue=question.isAnswerTrue();
        mQuestTextView.setText(questionId);
    }
}