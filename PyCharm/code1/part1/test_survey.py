import unittest
from survey import AnonymousSurvey


class TestAnonymousSurvey(unittest.TestCase):
    def test_store_single_response(self):
        question = "What langugage did you first learn to speak?"
        my_survey = AnonymousSurvey(question)
        my_survey.store_response('English')
        self.assertIn('English', my_survey.responses)

    def setUp(self):
        """创建一个调查对象和一组答案，供使用的测试方法使用。"""
        question="What language did you first learn to speak?"
        self.my_survey=AnonymousSurvey(question)
        self.responses=['English', 'Spanish', 'Mandarin']
    def test_store_three_response(self):
        responses=['English', 'Spanish', 'Mandarin']
        for response in responses:
            self.my_survey.store_response(response)
        for response in responses:
            self.assertIn(response, self.my_survey.responses)


if __name__ == '__main__':
    unittest.main
