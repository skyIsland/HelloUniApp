<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="数据字典编码" prop="DictionaryItemCode">
          <a-input v-model="entity.DictionaryItemCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数据字典项文本" prop="DictionaryItemText">
          <a-input v-model="entity.DictionaryItemText" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="所属数据字典" prop="DictionaryId">
          <c-select
          v-model="entity.DictionaryId"
          url="/Base_Manage/IsMatch_Dictionary/GetOptionList"
          searchMode="server"
        ></c-select>          
        </a-form-model-item>
        <a-form-model-item label="排序" prop="Rank">
          <a-input v-model="entity.Rank" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
import CSelect from '@/components/CSelect/CSelect'
export default {
  components:{
    CSelect
  },
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/Base_Manage/IsMatch_DictionaryItems/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/Base_Manage/IsMatch_DictionaryItems/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
